using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class JumpState : State
    {
        PlayerController entity;
        bool falling;

        public JumpState(PlayerController entity, StateMachine state) : base(state)
        {
                this.entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            entity.anim.SetBool("Jump", true);
            entity.Move(Vector2.up * Time.fixedDeltaTime * entity.jumpForce, ForceMode2D.Impulse);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log(entity.IsGrounded());
            if(entity.IsGrounded())
                state.ChangeState(entity.idleState);

        }

        public override void Exit()
        {
            base.Exit();
            entity.anim.SetBool("Jump", false);
        }
    }
}
