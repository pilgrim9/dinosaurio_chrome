using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Jump jump;
    private void Awake() {
        jump = GetComponent<Jump>();
    }

    bool isGrounded = true;
    // Update is called once per frame
    void Update()
    {
        if (isGrounded &&  Input.GetKeyDown(KeyCode.Space) ) {
            jump.jump();
            isGrounded = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
