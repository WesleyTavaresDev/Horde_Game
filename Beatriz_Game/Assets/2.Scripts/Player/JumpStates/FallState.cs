using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   
    public class FallState : MonoBehaviour
    {
        public delegate void OnFall();
        public static event OnFall onFall;

        [SerializeField] private float fallForce;

        private Rigidbody2D rb;
        private PlayerJumpController jumpController;
        private PlayerController player;    
        private Animator anim;
        private readonly int fallHash = Animator.StringToHash("Fall");

        private void Start() 
        {
            jumpController = GetComponent<PlayerJumpController>();
            player = GetComponent<PlayerController>();

            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void OnEnable() 
        {
            onFall += Fall;
            LandState.onLand += StopFallAnimation;
        } 

        private void OnDisable()
        {
            onFall -= Fall;
            LandState.onLand -= StopFallAnimation;
        } 

        private void Update()
        {
            if(rb.velocity.y < 0f && !jumpController.OnGround)
                onFall?.Invoke();
        }
        private void Fall()
        {
            anim.SetBool(fallHash, true);
            anim.SetBool("Jump", false);
            rb.velocity += Vector2.down * player.stats.GetStat(PlayerStatsEnum.fallForce) * Time.fixedDeltaTime;     
        }

        private void StopFallAnimation() => anim.SetBool(fallHash, false);
    }
}
