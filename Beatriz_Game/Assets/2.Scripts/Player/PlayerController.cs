using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player 
{ 
    public class PlayerController : MonoBehaviour
    {
        
        [HideInInspector] public StateMachine playerSM;
        [HideInInspector] public IdleState idleState;
        [HideInInspector] public RunState runState;
        [HideInInspector] public JumpState jumpState;

        [HideInInspector] public PlayerInput input;
        [HideInInspector] public InputAction move;
        [SerializeField] private Vector2 checkerRadius;
        [Header("Movement", order = 1)]
        public float horizontalInput;
        public float maxHorizontalSpeed;
        public float smoothTime;
        [HideInInspector] public float currentRef;
        [Header("Jump", order = 2)]
        public float jumpForce;

        public Animator anim;
        public Rigidbody2D rb;
        public BoxCollider2D coll;

        #region MonoBehaviour
        void Awake()
        {
            coll = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();
            rb = GetComponent<Rigidbody2D>();

            playerSM = new();
            idleState = new(this, playerSM);
            runState = new(this, playerSM);
            jumpState = new(this, playerSM);

            playerSM.Initialize(idleState);
        }

        void Start()
        {
            move = input.actions["Move"];
	}

        void Update()
        {
            playerSM.currentState.HandleInput();
            playerSM.currentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            playerSM.currentState.PhysicsUpdate();
        }

        #endregion

        #region Movement
        
        public void Move(Vector2 force, ForceMode2D forceMode2D)
        {
            rb.AddForce(force * Time.deltaTime, forceMode2D);
        }

        public InputAction GetJumpInput() => input.actions["Jump"];        
        #endregion
        
        #region checker

        public bool IsGrounded()
        {
            return Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius, 0, Vector2.zero, 0, 1 << 7);
        }

        #endregion
        

        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius);
        }
    }
}
