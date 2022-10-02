using UnityEngine;

[RequireComponent(typeof(JumpBehaviour))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    JumpBehaviour jump;
    [HideInInspector] public  bool isGrounded = true;
    private void Awake() {
        jump = GetComponent<JumpBehaviour>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isGrounded &&  Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
        }   
    }

    public void Jump()
    {
        jump.Jump();
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
