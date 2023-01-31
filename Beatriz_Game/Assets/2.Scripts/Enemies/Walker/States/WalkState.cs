using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : AliveState
{
    public WalkState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {}

    public override void Enter()
    {
        base.Enter();
        walker.anim.SetBool("Walking", true);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        float distanceDestination = (walker.points[walker.targetIndex] - walker.gameObject.transform.position.x);
        Debug.Log(distanceDestination);

        if(walker.targetIndex == 0)
        {
            if(distanceDestination <= 0.1f)
                state.ChangeState(walker.idleState);
        }
        else if( walker.targetIndex == 1)
            if(distanceDestination > 0)
                state.ChangeState(walker.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        walker.Move(Vector2.right * walker.GetDirection() * walker.speed * Time.deltaTime);
    }

    public override void Exit()
    {
        base.Exit();
        walker.rb.velocity -= walker.rb.velocity;
        walker.anim.SetBool("Walking", false);

    }
}
