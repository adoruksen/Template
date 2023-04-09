using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.StateMachine
{
    public class StackState : State
    {
        protected override void OnStateEnter(CharacterController controller)
        {
            //engellere carpýnca stack kaybetme ac
        }

        protected override void OnStateExit(CharacterController controller)
        {
            //stack kaybetme kapa
        }
    }
}

