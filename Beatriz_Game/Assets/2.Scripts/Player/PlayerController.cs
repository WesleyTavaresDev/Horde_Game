using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{ 
    public class PlayerController : MonoBehaviour
    {
        public StateMachine playerSM;
        void Awake()
        {
    
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
