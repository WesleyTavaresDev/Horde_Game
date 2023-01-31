using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactState : AliveState
{
    private float timeInReact;
    public ReactState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
        timeInReact = walker.reactTime;
        walker.anim.SetBool("React", true);
    }

    public override void LogicUpdate()
    {

        timeInReact -= Time.deltaTime;

        if(timeInReact <= 0)
            state.ChangeState(walker.attackState);

        if(!walker.IsPlayerClose())
            state.ChangeState(walker.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        walker.anim.SetBool("React", false);
    }
}
