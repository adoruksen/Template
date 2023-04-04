using System;
using UnityEngine;

namespace Character.StateMachine.Player
{
    [Serializable]
    public class PlayerGameState : GameState
    {
        public override void OnStateFixedUpdate(CharacterController controller)
        {
            var offset = Managers.InputManager.Module.NormalizedOffset;
            var direction = new Vector3(offset.x, 0f, offset.y);
            controller.Movement.Move(direction);
            if (offset.sqrMagnitude > .001f) controller.Movement.Look(direction);
        }
    }
}

