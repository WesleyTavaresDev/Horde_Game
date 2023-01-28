using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerStateMachine : MonoBehaviour
{
    private StateMachine walkerSM;
    [HideInInspector] public IdleState idleState;
    void Start()
    {
        walkerSM = new();
        
        idleState = new(this, walkerSM);

    }

    void Update()
    {
        walkerSM.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        walkerSM.currentState.PhysicsUpdate();
    }


}
