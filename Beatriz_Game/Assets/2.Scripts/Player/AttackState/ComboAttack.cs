using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ComboAttack : State
    {
        PlayerController player;
        private float comboTime;
        
        public ComboAttack(PlayerController player, StateMachine state) : base(state)
        {
            this.player = player;
        }

        public override void Enter()
        {
            base.Enter();
            player.damage = player.stats.GetStat(PlayerStatsEnum.comboAttackDamage);
            player.anim.SetBool("AttackCombo", true);
            comboTime = player.stats.comboAttackClip.length;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            comboTime -= Time.deltaTime;
            if(comboTime <= 0f)
                state.ChangeState(player.idleState);
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("AttackCombo", false);
        }
    }
}
