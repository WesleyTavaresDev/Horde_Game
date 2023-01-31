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

        float distance = Mathf.Abs(walker.points[walker.targetIndex] - walker.gameObject.transform.position.x);
        Debug.Log(distance);

        if(distance <= 0.1f)
            state.ChangeState(walker.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        walker.rb.AddForce(Vector2.right * walker.GetDirection() * walker.speed * Time.deltaTime, ForceMode2D.Force);
    }

    public override void Exit()
    {
        base.Exit();
        walker.rb.velocity -= walker.rb.velocity;
        walker.anim.SetBool("Walking", false);
    }
}
