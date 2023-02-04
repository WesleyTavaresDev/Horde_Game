using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public delegate void OnHit();
    public static event OnHit onHit;

    public delegate void OnDie();
    public static event OnDie onDie;

    public delegate void UiLife(float lifePoints, float maxLifePoints);
    public static event UiLife uiLife; 

    [SerializeField] private Vector2 knockbackForce;
    [SerializeField] private LayerMask dangerMask;
    [SerializeField] private float life;
    [SerializeField] private bool invencible;
    [SerializeField] private Collider2D coll;
    private PlayerController player;
    private Rigidbody2D rb;
    private float damageTaken;

    void Start()
    {
        player = GetComponent<PlayerController>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        life = player.stats.GetStat(PlayerStatsEnum.healthPoints);
    }

    void Update()
    {
        if(IsAttacked() && !invencible)
        {
            ApplyDamage(damageTaken);
            StartCoroutine(CameraShake.instance.Shake(0.1f, 0.1f));
        }
    }

    private void FixedUpdate() {
        if(IsAttacked() && !invencible)
            Knockback();
    }

    private void Knockback() 
    {
        int direction = transform.localEulerAngles.y == 0 ? -1 : 1;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(direction * knockbackForce.x * Time.deltaTime, knockbackForce.y * Time.deltaTime), ForceMode2D.Impulse);
    }

    private void ApplyDamage(float damage)
    {
        life -= damage;
        uiLife?.Invoke(life, player.stats.GetStat(PlayerStatsEnum.healthPoints));
        damageTaken = 0;

        StartCoroutine(ImmuneToDamage());   

        if(life > 0)
            onHit?.Invoke();
        else
            onDie?.Invoke();
    }

    private IEnumerator ImmuneToDamage()
    {
        invencible = true;
        yield return new WaitForSeconds(player.stats.GetStat(PlayerStatsEnum.invencibleTime));
        invencible = false;
    }

    private bool IsAttacked()
    {
        Collider2D enemy = Physics2D.OverlapBox(coll.bounds.center,  new Vector2(coll.bounds.size.x + 0.02f, coll.bounds.size.y), 0f, dangerMask.value);
        
        if(enemy)
        {
           if(enemy.gameObject.TryGetComponent(out EnemyController status))
                damageTaken = status.enemyStats.GetStat(EnemyStatsEnum.damagePoints);  
           else if(enemy.gameObject.GetComponentInParent<EnemyController>() != null)
                damageTaken = enemy.gameObject.GetComponentInParent<EnemyController>().enemyStats.GetStat(EnemyStatsEnum.damagePoints);
        }
        return enemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;    

        Gizmos.DrawWireCube(coll.bounds.center, new Vector2(coll.bounds.size.x + 0.02f, coll.bounds.size.y));
    }
}
