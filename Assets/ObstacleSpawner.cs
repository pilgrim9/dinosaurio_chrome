using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public void spawn(GameObject obstacle) {
        obstacle.transform.position = transform.position;
        obstacle.SetActive(true);
    }
}
