using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class BatController : MonoBehaviour
    {
        public StateMachine batSM;
        public IdleState idleState;
        void Start()
        {
            idleState = new(this, batSM);
            batSM.Initialize(idleState);
        }

        void Update()
        {
            batSM.currentState.HandleInput();
            batSM.currentState.LogicUpdate();
        }

        void FixedUpdate() 
        {
            batSM.currentState.PhysicsUpdate();    
        }
    }
}
