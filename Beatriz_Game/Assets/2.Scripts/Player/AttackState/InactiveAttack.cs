using System;

namespace Player
{
    public class InactiveAttack : State
    {
        PlayerAttackController player;
        public InactiveAttack (PlayerAttackController player, StateMachine state) : base(state) => this.player = player;

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(player.attackInput.WasPerformedThisFrame() && !player.playerHit.IsHitting() && !player.playerDead.IsPlayerDead())
                state.ChangeState(player.attackState);
        }
    }
}
