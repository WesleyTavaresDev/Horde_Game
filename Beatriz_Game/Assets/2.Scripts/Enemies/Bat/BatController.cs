using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class BatController : MonoBehaviour
    {
        [HideInInspector] public StateMachine batSM;
        [HideInInspector] public IdleState idleState;
        [HideInInspector] public MoveState moveState;

        public GameObject player;

        [SerializeField] private float overlapRadius;
        public float speed;
        public Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            batSM = new();

            idleState = new(this, batSM);
            moveState = new(this, batSM);
            
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
