using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{   public class RunState : Grounded
    {
        private float movementInput;
        private float speed;

        public RunState(PlayerController player, StateMachine state) : base(player, state) => this.player = player;

        public override void Enter()
        {
            base.Enter();
          //  player.anim.SetBool("Moving", true);
        }

        public override void HandleInput()
        {
            base.HandleInput();
          //  movementInput = player.move.ReadValue<float>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
         /*   Flip();
            speed = Mathf.SmoothDamp(speed, player.maxHorizontalSpeed, ref player.currentRef, player.smoothTime);

            if(movementInput == 0)
                state.ChangeState(player.idleState);*/
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
           // Move(Vector2.right * speed * movementInput, ForceMode2D.Force);
        }

        public override void Exit()
        {
            base.Exit();
            player.rb.velocity -= new Vector2(Mathf.Lerp(player.rb.velocity.x, 0, 0f), 0f);
            player.anim.SetBool("Moving", false);
        }

     /*   private void Flip()
        {
            Vector2 rotation = player.gameObject.transform.eulerAngles;
            
            if(movementInput > 0 && rotation.y == 180)
                rotation.y = 0;
            else if(movementInput < 0 && rotation.y == 0)
                rotation.y = 180;

            player.gameObject.transform.eulerAngles = rotation;
        }*/
    }
}