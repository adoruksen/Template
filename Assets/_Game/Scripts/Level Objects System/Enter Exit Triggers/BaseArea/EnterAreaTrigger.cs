using LevelObjectsSystem;
using InteractionSystem;
using UnityEngine;

namespace Character
{
    public class EnterAreaTrigger : MonoBehaviour,IBeginInteract
    {
        private GameAreaManager _newArea;

        public bool IsInteractable { get; } = true;

        
        private void Awake()
        {
            _newArea = GetComponentInParent<GameAreaManager>();
        }

        public void OnInteractBegin(IInteractor interactor)
        {
            var controller = (CharacterController)interactor;
            controller.Movement.Bounds = _newArea.PlayArea;
            EnterGameArea(controller);
        }

        private void EnterGameArea(CharacterController controller)
        {
            _newArea.OnCharacterEntered(controller);
        }
    }
}

