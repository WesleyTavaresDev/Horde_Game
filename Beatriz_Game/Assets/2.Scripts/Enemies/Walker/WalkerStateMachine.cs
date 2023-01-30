using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerStateMachine : MonoBehaviour
{
    public Vector2 startPosition;
    public float speed;
    public float distanceToWalk;
    [HideInInspector] public WalkState walkState;
    [HideInInspector] public IdleState idleState;

    public Animator anim;
    public Rigidbody2D rb;
    private StateMachine walkerSM;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosition = this.gameObject.transform.position;

        walkerSM = new();
        
        idleState = new(this, walkerSM);
        walkState = new(this, walkerSM);

        walkerSM.Initialize(walkState);
    }

    void Update()
    {
        walkerSM.currentState.LogicUpdate();
        Debug.Log(DistanceFromStartPosition());
    }

    void FixedUpdate()
    {
        walkerSM.currentState.PhysicsUpdate();
    }

    public float DistanceFromStartPosition() => Mathf.Abs(startPosition.x - this.gameObject.transform.position.x);

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPosition, this.transform.position);     
    }
}
