using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   public class RunState : State
    {
        private PlayerController entity;

        public RunState(PlayerController entity, StateMachine state) : base(state) => this.entity = entity;

        public override void Enter()
        {
            base.Enter();
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

        public override void Exit()
        {
            base.Exit();
        }
    }
}