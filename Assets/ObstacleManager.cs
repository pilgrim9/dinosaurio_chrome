using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    ObstacleSpawner[] spawners;
    public float spawnRate = 1f;
    GameObject obstaclePrefab;
    Queue<GameObject> gameObjects = new Queue<GameObject>();
    public int maxObstacles = 10;

    public static ObstacleManager instance;
    private void Awake() {
        if (instance && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        obstaclePrefab = Resources.Load<GameObject>("Obstacle");
    }

    private void Start() {
        spawners = GetComponentsInChildren<ObstacleSpawner>();
        for (int i = 0; i < maxObstacles; i++) {
            GameObject gameObject = Instantiate(obstaclePrefab);
            gameObject.SetActive(false);
            Enqueue(gameObject);
        }
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }
    
    private void spawn() {
        int randomValue = UnityEngine.Random.Range(0, spawners.Length);
        GameObject obstacle = gameObjects.Dequeue();
        spawners[randomValue].spawn(obstacle);
    }

    public void Enqueue(GameObject gameObject) {
        gameObjects.Enqueue(gameObject);
    }
}
