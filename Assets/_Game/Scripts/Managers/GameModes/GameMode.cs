using System;
using UnityEngine;

namespace Managers.GameModes
{
    public abstract class GameMode : ScriptableObject
    {
        public abstract void InitializeGameMode();
        public abstract void StartGameMode(Action levelStart);
        public abstract void FailGameMode();
        public abstract void CompleteGameMode();
        public abstract void SkipGameMode();
        public abstract void DeinitializeGameMode();
    }
}

