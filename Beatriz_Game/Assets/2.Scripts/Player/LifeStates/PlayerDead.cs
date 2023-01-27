using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    private readonly int die = Animator.StringToHash("Dead");
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable() => PlayerLifeController.onDie += Die;

    private void OnDisable() => PlayerLifeController.onDie -= Die;

    private void Die()
    {
        anim.SetBool(die, true);
    }

    public bool IsPlayerDead() => anim.GetBool(die);
} 
