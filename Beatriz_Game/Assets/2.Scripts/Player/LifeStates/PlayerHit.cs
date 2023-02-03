using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private readonly int hit = Animator.StringToHash("Hitted");

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController player;
    private void Awake()
    {
        player  = GetComponent<PlayerController>();
        rb      = GetComponent<Rigidbody2D>();
        anim    = GetComponent<Animator>();
    }
    
    private void OnEnable() => PlayerLifeController.onHit += Hit;
    private void OnDisable() => PlayerLifeController.onHit -= Hit;
    
    private void Hit()
    {
        StartCoroutine(OnHit());
    } 

    private IEnumerator OnHit()
    {
        anim.SetBool(hit, true);    
        yield return new WaitForSeconds(player.stats.GetStat(PlayerStatsEnum.hitTime));
        anim.SetBool(hit, false);
    }

    public bool IsHitting() => anim.GetBool(hit);

}
