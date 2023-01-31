using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private WalkerStateMachine walker;
    public DeadState(WalkerStateMachine walker ,StateMachine state) : base(state) => this.walker = walker;

    public override void Enter()
    {
        base.Enter();
        walker.anim.SetBool("Dead", true);
    }
}
