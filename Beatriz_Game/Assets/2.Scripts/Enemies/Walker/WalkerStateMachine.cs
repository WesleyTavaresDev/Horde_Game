using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerStateMachine : Spawnable
{
    [HideInInspector] public WalkState walkState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public ReactState reactState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public HittedState hittedState;
    [HideInInspector] public DeadState deadState;
    
    [Header("Walk Points", order = 1)]
    public float startPosition;
    public List<float> points = new();
    public int targetIndex;
    public float distanceToWalk;

    [Header("Movement", order = 2)]
    public float speed;

    [Header("Player Sensor radius", order = 3)]
    public Vector2 sensorSize;

    public float idleTime;
    [Header("Attack", order = 4)]
    public float reactTime;
    public float hitTime;
    public AnimationClip attackClip;

    [Header("Life", order = 5)]
    public float life;
    
    private EnemyController enemyController;
    public Animator anim;
    public Rigidbody2D rb;
    private StateMachine walkerSM;
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        enemyController = GetComponent<EnemyController>();

        life = enemyController.enemyStats.GetStat(EnemyStatsEnum.healthPoints);
        AddStantardPoints();

        walkerSM = new();

        idleState = new(this, walkerSM);
        walkState = new(this, walkerSM);
        reactState = new(this, walkerSM);
        attackState = new(this, walkerSM);
        hittedState = new(this, walkerSM);
        deadState = new(this, walkerSM);

        walkerSM.Initialize(walkState);
    }
    public override void OnKill()
    {
        base.OnKill();
    }

    private void AddStantardPoints()
    {
        startPosition = this.gameObject.transform.position.x;

        points.Add(startPosition + distanceToWalk);
        points.Add(startPosition);
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

    public void Move(Vector2 force) => rb.AddForce(force, ForceMode2D.Force);

   
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("PlayerAttack"))
        {
            SubstractLife(other.GetComponentInParent<Player.PlayerAttackController>().damage);
       
            walkerSM.ChangeState(IsDead() ? deadState : hittedState);
        }
    }

    private void SubstractLife(float damage) => life -= damage;

    private bool IsDead() => life <= 0; 

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;        

        Gizmos.DrawWireCube((new Vector2(rb.worldCenterOfMass.x + (0.5f * GetDirection()).x, rb.worldCenterOfMass.y)), sensorSize);
    }
}
