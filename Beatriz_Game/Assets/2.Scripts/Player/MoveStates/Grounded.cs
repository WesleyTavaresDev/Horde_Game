using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Grounded : State
    {
        protected PlayerController entity;
        public Grounded(PlayerController entity, StateMachine state) : base(state)
        {
            this.entity = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        
        public void Move(Vector2 force, ForceMode2D forceMode2D)
        {
            entity.rb.AddForce(force * Time.deltaTime, forceMode2D);
        }

    }
}
