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
        [HideInInspector] public PlayerInput input;
        [HideInInspector] public InputAction attackInput;
        [HideInInspector] public bool attacking;
        [HideInInspector] public Animator anim;
    #endregion

        [Header("Attack", order = 2)]        
        public float damage;

        [Header("Attributes", order = 3)]
        public PlayerStats stats;
     
        #region MonoBehaviour
        void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();

            playerSM = new();
            attackState = new(this, playerSM);
            comboState = new(this, playerSM);
            
        }

        void Start()
        {
            attackInput = input.actions["AttackMeele"];
	    }

        void Update()
        {
          /*  playerSM.currentState.HandleInput();
            playerSM.currentState.LogicUpdate();*/
        }

        void FixedUpdate()
        {
           // playerSM.currentState.PhysicsUpdate();
        }
        #endregion

        public bool IsAttacking() => attacking;
    }
}