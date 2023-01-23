using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bat
{
    public class AttackState : State
    {
        BatController bat;
        public AttackState(BatController bat, StateMachine state) : base(state) => this.bat = bat;
    }
}
