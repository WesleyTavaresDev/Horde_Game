using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   public class RunState : Grounded
    {
        private float movementInput;
        private float speed;

        public RunState(PlayerController entity, StateMachine state) : base(entity, state) => this.entity = entity;

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
            Flip();
            speed = Mathf.SmoothDamp(speed, entity.maxHorizontalSpeed, ref entity.currentRef, entity.smoothTime);

            if(movementInput == 0)
                state.ChangeState(entity.idleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Move(Vector2.right * speed * movementInput, ForceMode2D.Force);
        }

        public override void Exit()
        {
            base.Exit();
            entity.rb.velocity -= new Vector2(Mathf.Lerp(entity.rb.velocity.x, 0, 0f), 0f);
            entity.anim.SetBool("Moving", false);
        }

        private void Flip()
        {
            Vector2 rotation = entity.gameObject.transform.eulerAngles;
            
            if(movementInput > 0 && rotation.y == 180)
                rotation.y = 0;
            else if(movementInput < 0 && rotation.y == 0)
                rotation.y = 180;

            entity.gameObject.transform.eulerAngles = rotation;
        }
    }
}