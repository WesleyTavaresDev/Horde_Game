using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class IdleState : State
    {
        BatController bat;
        public IdleState(BatController bat, StateMachine state) : base(state) => this.bat = bat;

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(bat.IsPlayerClose())
            {
                state.ChangeState(bat.moveState);
            }
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
