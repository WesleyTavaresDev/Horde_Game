using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   public class RunState : State
    {
        private PlayerController entity;
        private float movementInput;
        private float speed;

        public RunState(PlayerController entity, StateMachine state) : base(state) => this.entity = entity;

        public override void Enter()
        {
            base.Enter();
            entity.anim.SetBool("Moving", true);
        }

        public override void HandleInput()
        {
            base.HandleInput();
            movementInput = entity.move.ReadValue<float>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            speed = Mathf.SmoothDamp(speed, entity.maxHorizontalSpeed, ref entity.currentRef, entity.smoothTime);

            if(movementInput == 0)
                state.ChangeState(entity.idleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            entity.Move(Vector2.right * speed * movementInput, ForceMode2D.Force);
        }

        public override void Exit()
        {
            base.Exit();
            entity.anim.SetBool("Moving", false);
        }
    }
}