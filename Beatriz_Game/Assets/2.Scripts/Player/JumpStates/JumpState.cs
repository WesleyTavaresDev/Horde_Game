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
        private Animator anim;
        private PlayerJumpController jumpController;
        private PlayerAttackController playerAttackController;
        private readonly int jumpHash = Animator.StringToHash("Jump");


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<PlayerInput>();
            coll = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
            jumpController = GetComponent<PlayerJumpController>();
            playerAttackController = GetComponent<PlayerAttackController>();

            JumpInput().performed += OnJump;
        }
            

        private void OnJump(InputAction.CallbackContext context)
        {
            if(jumpController.OnGround && !playerAttackController.IsAttacking()) 
                Jump();
        }

        private void Jump()
        {
            anim.SetBool(jumpHash, true);
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        private InputAction JumpInput() => input.actions["Jump"];
        private void StopJumpAnimation() => anim.SetBool(jumpHash, false);

        private void OnEnable() => FallState.onFall += StopJumpAnimation;
        private void OnDisable() 
        { 
            JumpInput().performed -= OnJump;
            FallState.onFall -= StopJumpAnimation;
        }
    }
}
