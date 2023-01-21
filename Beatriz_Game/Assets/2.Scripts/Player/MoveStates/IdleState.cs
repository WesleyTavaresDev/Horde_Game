using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class IdleState : Grounded
    {
        public IdleState(PlayerController entity, StateMachine state) : base(entity,state)
        {
            this.entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            entity.anim.SetBool("Idle", true);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(entity.move.ReadValue<float>() != 0)
                state.ChangeState(entity.runState);
        }

        public override void Exit()
        {
            base.Exit();
            entity.anim.SetBool("Idle", false);
        }
    }
}