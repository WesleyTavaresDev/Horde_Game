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

        public PlayerInput input;
        public InputAction move;
        [Header("Movement", order = 1)]
        public float horizontalInput;

        public Animator anim;

        #region MonoBehaviour
        void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();
            playerSM = new();
            idleState = new(this, playerSM);
            runState = new(this, playerSM);

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

    }
}
