using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{ 
    public class PlayerController : MonoBehaviour, IDynamic
    {
        public StateMachine playerSM;
        public IdleState idleState;

        public Animator anim;
        void Awake()
        {
            anim = GetComponent<Animator>();

            playerSM = new();
            idleState = new(this, playerSM);

            playerSM.Initialize(idleState);
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
    }
}
