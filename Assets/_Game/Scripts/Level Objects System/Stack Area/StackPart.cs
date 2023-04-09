using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LevelObjectsSystem
{
    [Serializable]
    public class StackPart : LevelPart
    {
        [SerializeField] private StackAreaManager _manager;

        public override GameAreaManager SetupPart(Transform parent, GameAreaManager previousArea = null)
        {
            var manager = Object.Instantiate(_manager, parent);
            if (previousArea != null)
            {
                manager.PreviousArea = previousArea;
                var position = previousArea.GetNextAreaPosition();
                manager.MoveArea(position);
            }

            return manager;
        }
    }
}

