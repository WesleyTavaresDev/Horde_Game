using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerStateMachine : MonoBehaviour
{
    StateMachine walkerSM;
    void Start()
    {
        walkerSM = new();
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
