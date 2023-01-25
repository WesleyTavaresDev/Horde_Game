using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(PlayerController))]
    public class PlayerMovement : MonoBehaviour
    {  
        [SerializeField] private float maxHorizontalSpeed;
        [SerializeField] private float smoothTime;

        private InputAction move; 
        private float movementInput;
        private float speed;
        private float currentRef;
        private Rigidbody2D rb;
        private Animator anim;

        private void OnEnable() 
        {
            move.canceled +=  OnStop;
        }

        private void OnDisable() 
        {
            move.canceled -=  OnStop;
        }
        void Awake()
        {
            anim    = GetComponent<Animator>();
            rb      = GetComponent<Rigidbody2D>();
            move    = GetComponent<PlayerInput>().actions["Move"];
        }

        private void Update()
        {
            movementInput = move.ReadValue<float>(); 
        }

        private void FixedUpdate()
        {
            OnMove();
        }

        private void LateUpdate()
        {
            PlayMovementAnimation();
        }

        private void OnMove()
        {
            Flip();
            
            speed = move.ReadValue<float>() != 0  ? Mathf.SmoothDamp(speed, maxHorizontalSpeed, ref currentRef, smoothTime) : 0;
            rb.velocity += new Vector2(movementInput * Time.smoothDeltaTime * speed, 0f);
        }

        private void OnStop(InputAction.CallbackContext context)
        {
            rb.velocity -= new Vector2(rb.velocity.x, 0);
        }

        private void PlayMovementAnimation()
        {
            anim.SetBool("Moving", move.ReadValue<float>() != 0f);
        }

        private void Flip()
        {
            Vector2 rotation = this.transform.eulerAngles;
            
            if(movementInput > 0 && rotation.y == 180)
                rotation.y = 0;
            else if(movementInput < 0 && rotation.y == 0)
                rotation.y = 180;

            this.gameObject.transform.eulerAngles = rotation;
        }

    }
}
