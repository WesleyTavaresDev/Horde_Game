using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class IdleState : Grounded
    {
        public IdleState(PlayerController player, StateMachine state) : base(player,state)
        {
            this.player = player;
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.SetBool("Idle", true);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(player.move.WasPerformedThisFrame())
                state.ChangeState(player.runState);
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("Idle", false);
        }
    }
}