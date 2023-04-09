using UnityEngine;
using Managers;
using CharacterController = Character.CharacterController;


namespace LevelObjectsSystem
{
    public class BaseAreaManager : GameAreaManager
    {
        public override void OnCharacterEntered(CharacterController character)
        {
            character.Area.CurrentArea = this;
            character.SetState(character.GameState);
        }

        public override void OnCharacterExited(CharacterController character)
        {
            character.Area.PrevArea = this;
        }

    }
}

