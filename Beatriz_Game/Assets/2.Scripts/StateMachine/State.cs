using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected IDynamic entity;
    protected StateMachine state;

    protected State(IDynamic entity, StateMachine state)
    {
        this.entity = entity;
        this.state = state;
    }

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
