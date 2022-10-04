using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{     
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
