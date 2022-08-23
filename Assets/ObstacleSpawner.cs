using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public void spawn() {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
