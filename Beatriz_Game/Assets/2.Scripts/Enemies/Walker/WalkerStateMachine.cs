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
    public float hitTime;
    public AnimationClip attackClip;

    public float life;
    [HideInInspector] public WalkState walkState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public ReactState reactState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public HittedState hittedState;
    
    private EnemyController enemyController;
    public Animator anim;
    public Rigidbody2D rb;
    private StateMachine walkerSM;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        enemyController = GetComponent<EnemyController>();
        
        life = enemyController.enemyStats.GetStat(EnemyStatsEnum.healthPoints);
        startPosition = this.gameObject.transform.position.x;
        
        points.Add(startPosition + distanceToWalk);
        
        points.Add(startPosition);


        walkerSM = new();
        
        idleState = new(this, walkerSM);
        walkState = new(this, walkerSM);
        reactState = new(this, walkerSM);
        attackState = new(this, walkerSM);
        hittedState = new(this, walkerSM);

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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("PlayerAttack"))
        {
            SubstractLife(other.GetComponentInParent<Player.PlayerAttackController>().damage);

            if(!IsDead())
                walkerSM.ChangeState(hittedState);
        }
    }

    private void SubstractLife(float damage)
    {
        life -= damage;
    }

    private bool IsDead() => life <= 0; 

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;        

        Gizmos.DrawWireCube((new Vector2(rb.worldCenterOfMass.x + (0.5f * GetDirection()).x, rb.worldCenterOfMass.y)), sensorSize);
    }
}
