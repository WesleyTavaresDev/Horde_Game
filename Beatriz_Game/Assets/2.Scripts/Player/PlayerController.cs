using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player 
{ 
    public class PlayerController : MonoBehaviour
    {
        #region States and Components
        [HideInInspector] public StateMachine playerSM;
        [HideInInspector] public IdleState idleState;
        [HideInInspector] public RunState runState; 
        [HideInInspector] public Attack attackState;
        [HideInInspector] public ComboAttack comboState;
        [HideInInspector] public PlayerInput input;
        [HideInInspector] public InputAction move;
        [HideInInspector] public InputAction attackInput;
        [HideInInspector] public bool attacking;
        [HideInInspector] public Animator anim;
        [HideInInspector] public Rigidbody2D rb;
    #endregion

        [Header("Movement", order = 1)]
        public float maxHorizontalSpeed;
        public float smoothTime;
        [HideInInspector] public float currentRef;

        [Header("Attack", order = 2)]        
        public float damage;

        [Header("Attributes", order = 3)]
        public PlayerStats stats;
     
        #region MonoBehaviour
        void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();
            rb = GetComponent<Rigidbody2D>();

            playerSM = new();
            idleState = new(this, playerSM);
            runState = new(this, playerSM);
            attackState = new(this, playerSM);
            comboState = new(this, playerSM);
            
            playerSM.Initialize(idleState);
        }

        void Start()
        {
            move = input.actions["Move"];
            attackInput = input.actions["AttackMeele"];
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

        public bool IsAttacking() => attacking;
    }
}