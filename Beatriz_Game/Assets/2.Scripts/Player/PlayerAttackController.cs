using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player 
{ 
    public class PlayerAttackController : MonoBehaviour
    {
        #region States and Components
        [HideInInspector] public StateMachine playerSM;
        [HideInInspector] public Attack attackState;
        [HideInInspector] public ComboAttack comboState;
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