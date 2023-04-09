using UnityEngine;
using GridSystem;
using Collectables;
using Sirenix.OdinInspector;
using CharacterController = Character.CharacterController;

namespace LevelObjectsSystem
{
    public class StackAreaManager : GameAreaManager
    {
        [SerializeField] private GridController _grid;
        [SerializeField] private Transform _fillAreaPlacer;

        [SerializeField, BoxGroup("", false)] private StackFillAreaGenerator _fillAreaGenerator;

        private StackFillArea _activeFillArea;

        private Collectable[] _collectables;


        public override void OnCharacterEntered(CharacterController character)
        {
            character.Area.CurrentArea = this;
            character.SetState(character.StackState);
        }

        public override void OnCharacterExited(CharacterController character)
        {
            character.Area.PrevArea = this;
        }

        public void SpawnCollectables()
        {
            var emptySlots = _grid.GetEmptySlotIndices();
            if (emptySlots.Count <= 0) return;

            var slotIndex = Random.Range(0, emptySlots.Count);
            var collectable = _collectables[Random.Range(0, _collectables.Length)];

            _grid.AddItemToSlot(collectable.GetComponent<GridObject>(), emptySlots[slotIndex]);
        }
    }
}

