using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ComboAttack : State
    {
        PlayerController entity;
        private float comboTime;
        
        public ComboAttack(PlayerController entity, StateMachine state) : base(state)
        {
            this.entity = entity;
        }

        public override void Enter()
        {
            base.Enter();
            entity.anim.SetBool("AttackCombo", true);
            comboTime = entity.comboAttackClip.length;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            comboTime -= Time.deltaTime;
            if(comboTime <= 0f)
                state.ChangeState(entity.idleState);
        }

        public override void Exit()
        {
            base.Exit();
            entity.anim.SetBool("AttackCombo", false);
        }
    }
}
