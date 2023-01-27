using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
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
        Knockback();
    } 

    private IEnumerator OnHit()
    {
        anim.SetBool(hit, true);    
        yield return new WaitForSeconds(player.stats.GetStat(PlayerStatsEnum.hitTime));
        anim.SetBool(hit, false);
    }

    private void Knockback() 
    {
        int direction = transform.localEulerAngles.y == 0 ? -1 : 1;
        rb.AddForce(new Vector2(direction * knockbackForce * Time.deltaTime, 1 * knockbackForce * Time.deltaTime), ForceMode2D.Impulse);
    }

    public bool IsHitting() => anim.GetBool(hit);

}
