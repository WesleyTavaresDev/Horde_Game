using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class JumpState : State
    {
        PlayerController entity;
        public JumpState(PlayerController entity, StateMachine state) : base(state)
        {
                this.entity = entity;
        }
    }
}
