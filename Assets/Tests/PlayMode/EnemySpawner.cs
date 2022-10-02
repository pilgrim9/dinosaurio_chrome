using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

namespace Tests.Playmode
{
    public class EnemySpawnerTest
    {

        ObstacleManager makeObstacleManager()
        {
            GameObject obstacleManagerGameObject = new GameObject();
            obstacleManagerGameObject.AddComponent<ObstacleManager>();
            
            GameObject obstacleSpawner = new GameObject();
            obstacleSpawner.AddComponent<ObstacleSpawner>();
            obstacleSpawner.transform.parent = obstacleManagerGameObject.transform;

            return obstacleManagerGameObject.GetComponent<ObstacleManager>();
        }
        
        [UnityTest]
        public IEnumerator RandomEnemyCountSpawned()
        {
            ObstacleManager obstacleManager = makeObstacleManager();
            obstacleManager.spawnRate = 1f;
            int randomEnemyCount = Random.Range(1, 6);
            obstacleManager.maxObstacles = randomEnemyCount;
            // Wait for a frame to ensure the obstacle manager has started
            yield return null;
            obstacleManager.spawnRate = 1f;
            yield return new WaitForSeconds(obstacleManager.spawnRate * (randomEnemyCount +1));
            // FindGameObjectsWithTag finds only active game objects
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            Assert.AreEqual(randomEnemyCount, obstacles.Count());
        }

        [UnityTest]
        public IEnumerator EnemyDestroyed()
        {
            ObstacleManager obstacleManager = makeObstacleManager();
            obstacleManager.maxObstacles = 3;
            obstacleManager.spawnRate = 0.2f;
            yield return new WaitForSeconds(obstacleManager.spawnRate * obstacleManager.maxObstacles);
            obstacleManager.spawnRate = 100f;
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            // Count active obstacles
            Assert.AreEqual(3, obstacles.Count());

            GameObject killZone = new GameObject();
            killZone.AddComponent<BoxCollider2D>();
            killZone.GetComponent<Collider2D>().isTrigger = true;
            killZone.tag = "DestroyZone";
            Vector3 killzoneOffset = new Vector3(-3, 0, 0);
            killZone.transform.position = killzoneOffset;
            Assert.AreEqual(obstacleManager.transform.position.x - 3, killZone.transform.position.x, 0.1f);

            float expectedTimeToCollision = 3 / obstacles[0].GetComponent<Move>().moveSpeed;
            yield return new WaitForSeconds(expectedTimeToCollision + 1);
            // Count inactive
            Assert.AreEqual(3, obstacles.Where(obstacle => !obstacle.activeSelf).Count());
            foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (obj.name.Contains("tests runner")) continue;
                GameObject.Destroy(obj);
            }
        }
    } 
}

