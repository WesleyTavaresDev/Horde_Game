using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Grounded : State
    {
        protected PlayerController player;
        public Grounded(PlayerController player, StateMachine state) : base(state)
        {
            this.player = player;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(player.attackInput.WasPerformedThisFrame())
                state.ChangeState(player.attackState);
        }
        
        public void Move(Vector2 force, ForceMode2D forceMode2D)
        {
            player.rb.AddForce(force * Time.deltaTime, forceMode2D);
        }

    }
}
