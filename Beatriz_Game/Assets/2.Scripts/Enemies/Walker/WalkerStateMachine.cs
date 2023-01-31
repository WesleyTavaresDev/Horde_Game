using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerStateMachine : MonoBehaviour
{
    public float startPosition;
    public List<float> points = new();
    public int targetIndex;

    public float speed;
    public float distanceToWalk;

    public Vector2 sensorSize;
    public float reactTime;
    public float idleTime;
    [HideInInspector] public WalkState walkState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public ReactState reactState;

    public Animator anim;
    public Rigidbody2D rb;
    private StateMachine walkerSM;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startPosition = this.gameObject.transform.position.x;
        
        points.Add(startPosition + distanceToWalk);
        
        points.Add(startPosition);


        walkerSM = new();
        
        idleState = new(this, walkerSM);
        walkState = new(this, walkerSM);
        reactState = new(this, walkerSM);

        walkerSM.Initialize(walkState);
    }

    void Update()
    {
        walkerSM.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        walkerSM.currentState.PhysicsUpdate();
    }

    public bool IsPlayerClose() => Physics2D.OverlapBox((new Vector2(rb.worldCenterOfMass.x + (0.5f * GetDirection()).x, rb.worldCenterOfMass.y)), sensorSize, 0, 1 << 6);

    public Vector2 GetDirection() => transform.localScale.x >= 0 ? Vector2.right : Vector2.left;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;        

        Gizmos.DrawWireCube((new Vector2(rb.worldCenterOfMass.x + (0.5f * GetDirection()).x, rb.worldCenterOfMass.y)), sensorSize);
    }
}
