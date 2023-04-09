using Vehicle;
using LevelObjectsSystem;
using Managers;
using UnityEngine;

namespace Character
{
    public class CharacterDriveStateTrigger : MonoBehaviour
    {
        private VehicleController _vehicle;
        private StackFillArea _fillArea;
        private GameAreaManager _stackArea;

        private void Awake()
        {
            _fillArea = GetComponent<StackFillArea>();
            _stackArea = GetComponentInParent<GameAreaManager>();
        }

        private void OnEnable()
        {
            _fillArea.OnCompleted += UpdateCharacterState;
        }

        private void OnDisable()
        {
            _fillArea.OnCompleted -= UpdateCharacterState;
        }

        public void SetVehicle(VehicleController vehicle)
        {
            _vehicle = vehicle;
        }

        private void UpdateCharacterState()
        {
            var character = CharacterManager.instance.Player;
            character.SetState(character.EnterVehicleState);
            character.Vehicle = _vehicle;
            _stackArea.OnCharacterExited(character);
        }
    }
}

