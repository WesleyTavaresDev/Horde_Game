using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class AttackState : State
    {
        float cooldown;
        float time;
        BatController bat;
        public AttackState(BatController bat, StateMachine state) : base(state) => this.bat = bat;

        public override void Enter()
        {
            base.Enter();
            cooldown = 0;
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(cooldown <= 0f && !bat.coll.enabled)
                Attack();
            else
                cooldown -= Time.deltaTime;

            if(bat.coll.enabled)
                StopAttack();

            if(!bat.IsPlayerClose())
                state.ChangeState(bat.idleState);
        }

        void Attack()
        {
            bat.coll.enabled = true;
            time = bat.activeColliderTime;
        }

        void StopAttack()
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            if(time <= 0f)
            {
                bat.coll.enabled = false;
                cooldown = bat.cooldownAttack;
            }  
        }
    }
}
