using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Player 
{ 
    public class PlayerAttackController : MonoBehaviour
    {
        public UnityEvent basicAttack;
        public UnityEvent comboAttack;
        #region States and Components
        [HideInInspector] public StateMachine playerSM;
        [HideInInspector] public Attack attackState;
        [HideInInspector] public ComboAttack comboState;
        [HideInInspector] public PlayerHit playerHit;
        [HideInInspector] public PlayerDead playerDead;
        [HideInInspector] public InactiveAttack inactive;
        [HideInInspector] public PlayerInput input;
        [HideInInspector] public InputAction attackInput;
        [HideInInspector] public bool attacking;
        [HideInInspector] public Animator anim;
    #endregion

        public float damage;

        public PlayerController playerController;
     
        #region MonoBehaviour
        void Awake()
        {
            playerController = GetComponent<PlayerController>();
            playerHit = GetComponent<PlayerHit>();
            playerDead = GetComponent<PlayerDead>();
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();

            playerSM = new();
            inactive = new(this, playerSM);
            attackState = new(this, playerSM);
            comboState = new(this, playerSM);
            
            playerSM.Initialize(inactive);
        }

        void Start() => attackInput = input.actions["AttackMeele"];
	    

        void Update()
        {
            playerSM.currentState.HandleInput();
            playerSM.currentState.LogicUpdate();
        }

        void FixedUpdate() => playerSM.currentState.PhysicsUpdate();
        
        #endregion

        public bool IsAttacking() => attacking;
    }
}