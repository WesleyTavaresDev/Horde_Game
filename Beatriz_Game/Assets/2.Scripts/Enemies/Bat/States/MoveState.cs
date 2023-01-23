using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy.Bat
{
    public class MoveState : State
    {

        Vector2 target;
        BatController bat;
        public MoveState(BatController bat, StateMachine state) : base(state) => this.bat = bat;

        public override void Enter()
        {
            base.Enter();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            target = new Vector2(bat.player.transform.position.x - bat.gameObject.transform.position.x,
            bat.player.transform.position.y - bat.gameObject.transform.position.y).normalized;
        }
 
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if(Vector2.Distance(bat.gameObject.transform.position, bat.player.transform.position) > 1.5f)
                Move(target);
            else
                bat.rb.velocity -= bat.rb.velocity;
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void Move(Vector2 direction)
        {
            
            bat.rb.AddForce(direction * bat.speed, ForceMode2D.Force);
        }
    }
}   
