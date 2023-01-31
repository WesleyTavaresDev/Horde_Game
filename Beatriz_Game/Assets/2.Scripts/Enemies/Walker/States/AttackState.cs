using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AliveState
{
    private float attackTime;
    public AttackState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
        walker.anim.SetBool("Attack", true);
        attackTime = walker.attackClip.length;
    }

    public override void LogicUpdate()
    {
        attackTime -= Time.deltaTime;

        if(attackTime < 0f)
            state.ChangeState(walker.reactState);
    }

    public override void Exit()
    {
        base.Exit();
        walker.anim.SetBool("Attack", false);
    }
}
