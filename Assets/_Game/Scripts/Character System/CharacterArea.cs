using LevelObjectsSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    public class CharacterArea : MonoBehaviour
    {
        [ShowInInspector] public GameAreaManager CurrentArea { get; set; }
        [ShowInInspector] public GameAreaManager PrevArea { get; set; }

    }
}

