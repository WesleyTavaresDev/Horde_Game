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
        walker.OnKill();
        walker.anim.SetBool("Dead", true);
        walker.rb.bodyType = RigidbodyType2D.Static;
        Collider2D[] collidersToBeDisabled = walker.gameObject.GetComponents<BoxCollider2D>();
        for(int i = 0; i < collidersToBeDisabled.Length; i++)
            collidersToBeDisabled[i].enabled = false;
    }
}
