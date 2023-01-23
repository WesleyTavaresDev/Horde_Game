using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class DeadState : State
    {
        BatController bat;
        public DeadState(BatController bat, StateMachine state) : base(state) => this.bat = bat;

        public override void Enter()
        {
            base.Enter();
            Destroy(bat.gameObject);
        }
    }
}