using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    JumpBehaviour jump;
    bool isGrounded = true;
    private void Awake() {
        jump = GetComponent<JumpBehaviour>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isGrounded &&  Input.GetKeyDown(KeyCode.Space) ) {
            jump.Jump();
            isGrounded = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
