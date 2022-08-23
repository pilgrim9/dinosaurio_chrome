using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    ObstacleSpawner[] spawners;
    public float spawnRate = 1f;

    private void Awake() {
        spawners = GetComponentsInChildren<ObstacleSpawner>();
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }
    private void spawn() {
        spawners[UnityEngine.Random.Range(0, spawners.Length)].spawn();
    }
}
