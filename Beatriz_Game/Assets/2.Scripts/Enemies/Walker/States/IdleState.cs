using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AliveState
{
    public IdleState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
