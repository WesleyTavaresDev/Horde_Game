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
        [HideInInspector] public AttackState attackState;

        [Header("Movement", order =1)]
        public GameObject player;
        
        [Header("Attack", order = 2)]
        public float cooldownAttack;
        public float activeColliderTime;
        [SerializeField] private float overlapRadius;
        public float speed;
        public Rigidbody2D rb;
        public Collider2D coll;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
            coll.enabled = false;

            batSM = new();

            idleState = new(this, batSM);
            moveState = new(this, batSM);
            attackState = new(this, batSM);

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

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("PlayerAttack"))
                Destroy(this.gameObject);    
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
