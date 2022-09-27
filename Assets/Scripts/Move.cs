using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate( moveSpeed * Time.deltaTime * moveDirection);
    }
}
