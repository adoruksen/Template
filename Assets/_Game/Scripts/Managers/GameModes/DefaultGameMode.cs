using System;
using LevelSystem;
using UI;
using DG.Tweening;
using UnityEngine;

namespace Managers.GameModes
{
    [CreateAssetMenu(menuName = "Game/GameMode/DefaultGameMode", fileName = "DefaultGameMode", order = -399)]
    public class DefaultGameMode : GameMode
    {
        public Level[] Levels;

        public override void InitializeGameMode()
        {
            var config = Levels[GameManager.instance.GetSavedLevel() % Levels.Length];
            LevelManager.instance.SpawnLevel(config.Parts);
            CharacterManager.instance.SpawnCharacters(Vector3.zero, Vector3.one);
            foreach (var character in CharacterManager.instance.GetCharacters())
            {
                var startArea = LevelManager.instance.ThisLevel.GameAreas[0];
                character.Movement.Bounds = startArea.PlayArea;
                startArea.OnCharacterEntered(character);
            }
        }

        public override void StartGameMode(Action levelStart)
        {
            levelStart.Invoke();
        }

        public override void CompleteGameMode()
        {
            GameManager.instance.SaveLevel(GameManager.instance.GetSavedLevel() + 1);
            DOVirtual.DelayedCall(1.5f, WinUiController.Instance.Show, false);
        }

        public override void FailGameMode()
        {
            DOVirtual.DelayedCall(1.5f, FailUiController.Instance.Show, false);
        }

        public override void SkipGameMode()
        {
            GameManager.instance.SaveLevel(GameManager.instance.GetSavedLevel() + 1);
        }

        public override void DeinitializeGameMode()
        {
            LevelManager.instance.DestroyLevel();
        }
    }
}

