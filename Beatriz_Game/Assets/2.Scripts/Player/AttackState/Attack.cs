using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Attack : State
{
    private float attackTime;
    private bool combo;
    PlayerAttackController player;
    
    public Attack(PlayerAttackController entity, StateMachine state) : base(state)
    {
        this.player = entity; 
    }

    public override void Enter()
    {
        base.Enter();
        player.anim.SetBool("Attack", true);
        
        player.damage = player.stats.GetStat(PlayerStatsEnum.normalAttackDamage);

        attackTime = player.stats.attackClip.length;
        combo = false;
        player.attacking = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(player.attackInput.WasPressedThisFrame())
            combo = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        attackTime -= Time.deltaTime;

        if(attackTime <= 0f)
        {   
            state.ChangeState(player.comboState );
        }   
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("Attack", false);

        player.attacking = false;
    }
}
