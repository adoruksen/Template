using LevelObjectsSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game/Level", order = 1)]

public class Level : ScriptableObject
{
    [SerializeReference] public LevelPart[] Parts;
}