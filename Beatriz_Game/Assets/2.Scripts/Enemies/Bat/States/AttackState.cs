using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class AttackState : State
    {
        BatController bat;
        public AttackState(BatController bat, StateMachine state) : base(state) => this.bat = bat;

        public override void Enter()
        {
            base.Enter();
            Attack();
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(!bat.IsPlayerClose())
                state.ChangeState(bat.idleState);
        }

        void Attack()
        {
            bat.coll.enabled = true;
        }
    }
}
