using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ComboAttack : State
    {
        PlayerController entity;
        
        public ComboAttack(PlayerController entity, StateMachine state) : base(state)
        {
            this.entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Combo");
        }
    }
}
