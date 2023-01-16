using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class IdleState : State
    {
        PlayerController entity;
        public IdleState(PlayerController entity, StateMachine state) : base(entity, state){}

        public override void Enter()
        {
            base.Enter();
            entity.anim.SetBool("Idle", true);
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
        }
    }
}