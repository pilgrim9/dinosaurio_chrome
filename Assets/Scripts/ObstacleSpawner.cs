using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public void Spawn(GameObject obstacle) {
        obstacle.transform.position = transform.position;
        obstacle.SetActive(true);
    }
}
