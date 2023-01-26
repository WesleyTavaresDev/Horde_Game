using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   
    public class FallState : MonoBehaviour
    {
        [SerializeField] private float fallForce;

        private Rigidbody2D rb;
        private PlayerJumpController jumpController;
        private Animator anim;
        private readonly int fallHash = Animator.StringToHash("Fall");

        private void Start() 
        {
            jumpController = GetComponent<PlayerJumpController>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void OnEnable() => LandState.onLand += StopFallAnimation;

        private void OnDisable() => LandState.onLand -= StopFallAnimation;

        private void Update()
        {
            if(rb.velocity.y < 0f && !jumpController.OnGround)
                Fall();
        }
        private void Fall()
        {
            anim.SetBool(fallHash, true);
            anim.SetBool("Jump", false);
            rb.velocity += Vector2.down * fallForce * Time.fixedDeltaTime;     
        }

        private void StopFallAnimation() => anim.SetBool(fallHash, false);


    }
}
