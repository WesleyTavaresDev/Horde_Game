using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AliveState
{
    private float timeInIdle;
    public IdleState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
        timeInIdle = walker.idleTime;
        walker.anim.SetBool("Idle", true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timeInIdle -= Time.deltaTime;
        if(timeInIdle <= 0f)
            state.ChangeState(walker.walkState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
        walker.targetIndex = (walker.targetIndex == 0) ? 1 : 0; 
        walker.anim.SetBool("Idle", false);
        
        Flip();
    }

      public void Flip()
    {
        Vector2 scale = walker.gameObject.transform.localScale;
        scale.x *= -1;
        walker.gameObject.transform.localScale = scale;
    }
}
