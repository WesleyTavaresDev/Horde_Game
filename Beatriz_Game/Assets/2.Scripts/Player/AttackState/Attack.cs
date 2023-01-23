using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Attack : State
{
    private float attackTime;
    private bool combo;
    PlayerController entity;
    
    public Attack(PlayerController entity, StateMachine state) : base(state)
    {
        this.entity = entity; 
    }

    public override void Enter()
    {
        base.Enter();
        entity.anim.SetBool("Attack", true);

        attackTime = entity.attackClip.length;
        combo = false;
        entity.attacking = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(entity.attackInput.WasPressedThisFrame())
            combo = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        attackTime -= Time.deltaTime;

        if(attackTime <= 0f)
        {   
            state.ChangeState(combo ? entity.comboState : entity.idleState);
        }   
            

    }

    public override void Exit()
    {
        base.Exit();
        entity.anim.SetBool("Attack", false);

        entity.attacking = false;
    }
}
