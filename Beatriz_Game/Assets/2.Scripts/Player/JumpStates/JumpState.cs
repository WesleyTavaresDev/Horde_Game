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
        private PlayerHit playerHit;
        private PlayerDead playerDead;

        private PlayerJumpController jumpController;
        private PlayerAttackController playerAttackController;
        private readonly int jumpHash = Animator.StringToHash("Jump");


        void Start()
        {
            playerDead = GetComponent<PlayerDead>();
            playerHit = GetComponent<PlayerHit>();
            input = GetComponent<PlayerInput>();

            coll = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            jumpController = GetComponent<PlayerJumpController>();
            playerAttackController = GetComponent<PlayerAttackController>();
        }
            
        private void Update() 
        {
            if (JumpInput().triggered)
                OnJumpPerformed(); 
        }

        private void OnJumpPerformed()
        {
            if(jumpController.OnGround && !playerAttackController.IsAttacking() && !playerHit.IsHitting() && !playerDead.IsPlayerDead()) 
                Jump(jumpForce);
        }

        private void Jump(float force)
        {
            anim.SetBool(jumpHash, true);
            rb.AddForce(Vector2.up * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        private InputAction JumpInput() => input.actions["Jump"];
        private void StopJumpAnimation() => anim.SetBool(jumpHash, false);

        private void OnEnable() => FallState.onFall += StopJumpAnimation;
        private void OnDisable() 
        { 
           // JumpInput().performed -= OnJumpPerformed;
            FallState.onFall -= StopJumpAnimation;
        }
    }
}
