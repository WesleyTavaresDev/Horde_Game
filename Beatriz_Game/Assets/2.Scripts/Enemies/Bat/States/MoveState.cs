using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy.Bat
{
    public class MoveState : State
    {
        BatController bat;
        public MoveState(BatController bat, StateMachine state) : base(state) => this.bat = bat; 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}   
