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

    [SerializeField] private LayerMask dangerMask;
    [SerializeField] private float life;
    [SerializeField] private bool invencible;
    [SerializeField] private Collider2D coll;
    private PlayerController player;
    private float damageTaken;

    void Start()
    {
        player = GetComponent<PlayerController>();
        coll = GetComponent<Collider2D>();

        life = player.stats.GetStat(PlayerStatsEnum.healthPoints);
    }

    void Update()
    {
        if(IsAttacked() && !invencible)
        {
            ApplyDamage(damageTaken);
        }
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
        Collider2D enemy = Physics2D.OverlapBox(coll.bounds.center, coll.bounds.size, 0f, dangerMask.value);
        
        if(enemy)
            damageTaken = enemy.gameObject.GetComponent<EnemyController>().enemyStats.GetStat(EnemyStatsEnum.damagePoints);
        
        return enemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;    

        Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);
    }
}
