using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class BatController : MonoBehaviour
    {
        [HideInInspector] public StateMachine batSM;
        [HideInInspector] public IdleState idleState;
        
        [SerializeField] private float overlapRadius;
        void Start()
        {
            batSM = new();

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

        public bool IsPlayerClose()
        {
            return Physics2D.OverlapCircle(transform.position, overlapRadius, 1 << 6);
        }
        
        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, overlapRadius);    
        }

    }
}
