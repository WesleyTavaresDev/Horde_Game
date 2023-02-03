using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ComboAttack : State
    {
        PlayerAttackController player;
        private float comboTime;
        
        public ComboAttack(PlayerAttackController player, StateMachine state) : base(state)
        {
            this.player = player;
        }

        public override void Enter()
        {
            base.Enter();
            player.damage = player.playerController.stats.GetStat(PlayerStatsEnum.comboAttackDamage);
            player.anim.SetBool("AttackCombo", true);
            comboTime = player.playerController.stats.comboAttackClip.length;

            player.comboAttack?.Invoke();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            comboTime -= Time.deltaTime;
            if(comboTime <= 0f)
                state.ChangeState(player.inactive);
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("AttackCombo", false);
        }
    }
}
