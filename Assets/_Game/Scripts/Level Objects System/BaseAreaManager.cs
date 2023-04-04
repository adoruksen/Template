using UnityEngine;
using Managers;
using CharacterController = Character.CharacterController;


namespace LevelObjectsSystem
{
    public class BaseAreaManager : GameAreaManager
    {
        public override void OnCharacterEntered(CharacterController character)
        {
            if (!GameManager.instance.IsPlaying) return;

            character.SetState(character.GameState);
        }
    }
}

