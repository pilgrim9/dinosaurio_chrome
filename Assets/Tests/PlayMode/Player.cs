using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Debug = UnityEngine.Debug;

namespace Tests.Playmode
{
    public class PlayerTest
    {
        [UnityTest]
        public IEnumerator PlayerJump()
        {
            GameObject floor = new GameObject();
            floor.AddComponent<BoxCollider2D>();
            floor.transform.position -= new Vector3(0, 2, 0);
            floor.tag = "Ground";
            
            GameObject player = new GameObject();
            player.AddComponent<BoxCollider2D>();
            player.AddComponent<Rigidbody2D>();
            player.AddComponent<CharacterController2D>();
            CharacterController2D characterController2D = player.GetComponent<CharacterController2D>();
            characterController2D.isGrounded = false;
            
            while (!characterController2D.isGrounded)
            {
                yield return null;
            }
            
            characterController2D.Jump();
            float timeBeforeJump = Time.time;
            while (!characterController2D.isGrounded)
            {
                yield return null;
            }

            float timeAfterJump = Time.time;
            float totalJumpTime = timeAfterJump - timeBeforeJump; 
            Vector3 startingPosition = player.transform.position;

            characterController2D.Jump();
            yield return new WaitForSeconds(totalJumpTime / 2);
            Vector3 jumpApexPosition = player.transform.position;
            Assert.IsTrue(jumpApexPosition.y > startingPosition.y);
            
            yield return new WaitForSeconds(totalJumpTime / 2);

            Assert.IsTrue(player.transform.position.y < jumpApexPosition.y);
            Assert.IsTrue(characterController2D.isGrounded);
        }
    }
}