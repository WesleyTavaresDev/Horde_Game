using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AliveState
{
    WalkerStateMachine walker;
   public IdleState(WalkerStateMachine walker, StateMachine state) : base(walker, state) {} 
}
