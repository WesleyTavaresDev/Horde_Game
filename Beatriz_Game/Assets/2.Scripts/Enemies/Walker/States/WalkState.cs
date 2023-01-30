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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(walker.DistanceFromStartPosition() < walker.distanceToWalk)
            walker.rb.AddForce(Vector2.right * walker.speed * Time.deltaTime, ForceMode2D.Force);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
