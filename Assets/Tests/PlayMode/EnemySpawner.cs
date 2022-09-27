using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;
namespace Tests.Playmode
{
    public class EnemySpawnerTest
    {

        [UnityTest]
        public IEnumerator RandomEnemyCountSpawned()
        {
            GameObject obstacleManagerGameObject = new GameObject();
            obstacleManagerGameObject.AddComponent<ObstacleManager>();
            GameObject obstacleSpawner = new GameObject();
            obstacleSpawner.AddComponent<ObstacleSpawner>();
            obstacleSpawner.transform.parent = obstacleManagerGameObject.transform;

            ObstacleManager obstacleManager = obstacleManagerGameObject.GetComponent<ObstacleManager>();
            obstacleManager.spawnRate = 0.1f;
            int randomEnemyCount = Random.Range(1, 6);
            obstacleManager.maxObstacles = randomEnemyCount;
            // Wait for a frame to ensure the obstacle manager has started
            yield return null;
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            yield return new WaitForSeconds(obstacleManager.spawnRate * randomEnemyCount);
            IEnumerable<GameObject> activeObstacles = obstacles.Where(obstacle => obstacle.activeSelf);
            Assert.AreEqual(randomEnemyCount, activeObstacles.Count());
        }
    } 
}

