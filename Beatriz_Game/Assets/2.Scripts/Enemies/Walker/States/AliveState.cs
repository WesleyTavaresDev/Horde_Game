using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveState : State
{
    WalkerStateMachine walker;
    public AliveState(WalkerStateMachine walker, StateMachine state) : base(state) => this.walker = walker; 
}
