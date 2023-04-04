using System;
using System.Collections.Generic;
using LevelSystem;
using LevelObjectsSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        public static event Action<LevelController> OnLevelSpawned;

        [ReadOnly] public LevelController ThisLevel;

        private void Awake()
        {
            instance = this;
        }

        [Button]
        public void SpawnLevel(LevelPart[] parts)
        {

            ThisLevel = new GameObject("Level").AddComponent<LevelController>();
            var gameAreas = new List<GameAreaManager>();

            var prevArea = parts[0].SetupPart(ThisLevel.transform);
            gameAreas.Add(prevArea);

            for (int i = 1; i < parts.Length; i++)
            {
                var area = parts[i].SetupPart(ThisLevel.transform, prevArea);
                gameAreas.Add(area);
                prevArea = area;
            }

            ThisLevel.GameAreas = gameAreas.ToArray();
                        
            OnLevelSpawned?.Invoke(ThisLevel);
        }

        public void DestroyLevel()
        {
            if (ThisLevel != null) Destroy(ThisLevel.gameObject);
        }
    }
}
