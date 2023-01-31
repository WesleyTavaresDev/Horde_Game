using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveState : State
{
    protected WalkerStateMachine walker;
    public AliveState(WalkerStateMachine walker, StateMachine state) : base(state) => this.walker = walker;

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(walker.IsPlayerClose())
        {
            state.ChangeState(walker.reactState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
