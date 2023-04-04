using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace LevelObjectsSystem
{
    [Serializable]
    public class BridgePart : LevelPart
    {
        [SerializeField] private BridgeAreaManager _manager;
        public override GameAreaManager SetupPart(Transform parent, GameAreaManager previousArea = null)
        {
            var manager = Object.Instantiate(_manager, parent);
            if (previousArea != null)
            {
                var position = previousArea.GetNextAreaPosition();
                manager.MoveArea(position);
            }

            return manager;
        }
    }
}

