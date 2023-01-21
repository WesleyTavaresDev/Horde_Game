using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class JumpState : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private BoxCollider2D coll;

        private PlayerInput input;
        private Rigidbody2D rb;
        private PlayerJumpController jumpController;
        private PlayerController playerController;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<PlayerInput>();
            coll = GetComponent<BoxCollider2D>();
            jumpController = GetComponent<PlayerJumpController>();
            playerController = GetComponent<PlayerController>();

            JumpInput().performed += OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            if(jumpController.OnGround && !playerController.IsAttacking()) 
                Jump();
        }

        private void Jump()
        {
            jumpController.PlayJumpAnimation();
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        private InputAction JumpInput() => input.actions["Jump"];

        private void OnDisable() => JumpInput().started -= OnJump;
    }
}
