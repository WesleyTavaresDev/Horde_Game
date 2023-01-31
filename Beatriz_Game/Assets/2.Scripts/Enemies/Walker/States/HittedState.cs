using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittedState : AliveState
{
    private float timeInHit;
    public HittedState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
        walker.anim.SetBool("Hit", true);
        timeInHit = walker.hitTime;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        timeInHit -= Time.deltaTime;

        if(timeInHit <= 0f)
            state.ChangeState(walker.walkState);
    }

    public override void Exit()
    {
        base.Exit();
        walker.anim.SetBool("Hit", false);
    }


}
