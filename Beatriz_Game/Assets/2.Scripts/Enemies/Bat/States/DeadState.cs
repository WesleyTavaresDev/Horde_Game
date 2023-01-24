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
            bat.anim.SetBool("BatDead", true);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            bat.rb.velocity -= new Vector2(0, 2 * Time.deltaTime);
        }
    }
}