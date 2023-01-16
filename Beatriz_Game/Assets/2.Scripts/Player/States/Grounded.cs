using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Grounded : State
    {
        PlayerController entity;
        public Grounded(PlayerController entity, StateMachine state) : base(state)
        {
            this.entity = entity;
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
    }
}
