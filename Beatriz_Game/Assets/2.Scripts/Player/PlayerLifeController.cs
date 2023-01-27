using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public delegate void OnHit();
    public static event OnHit onHit;

    [SerializeField] private LayerMask dangerMask;
    [SerializeField] private float life;
    [SerializeField] private bool invencible;
    [SerializeField] private Collider2D coll;
    private PlayerController player;

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
            ApplyDamage(1);
        }
    }

    private void ApplyDamage(float damage)
    {
        life -= damage;
        StartCoroutine(ImmuneToDamage());   

        if(life > 0)
            onHit?.Invoke();
        else
            Debug.Log("Dead");
    }

    private IEnumerator ImmuneToDamage()
    {
        invencible = true;
        yield return new WaitForSeconds(player.stats.GetStat(PlayerStatsEnum.invencibleTime));
        invencible = false;
    }

    private bool IsAttacked() => Physics2D.OverlapBox(coll.bounds.center, coll.bounds.size, 0f, dangerMask.value);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;    

        Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);
    }
}
