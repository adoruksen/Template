using LevelObjectsSystem;
using InteractionSystem;
using UnityEngine;

namespace Character
{
    public class EnterAreaTrigger : MonoBehaviour,IBeginInteract
    {
        private GameAreaManager _thisArea;
        [SerializeField] private GameAreaManager _prevArea;

        public bool IsInteractable { get; } = true;

        
        private void Awake()
        {
            _thisArea = GetComponentInParent<GameAreaManager>();
        }

        private void Start()
        {
            _prevArea = _thisArea.PreviousArea;
        }

        public void OnInteractBegin(IInteractor interactor)
        {
            var controller = (CharacterController)interactor;

            if(controller.Area.CurrentArea == _prevArea)
            {
                controller.Movement.Bounds = _thisArea.PlayArea;
                EnterGameArea(_thisArea,controller);
            }
            else
            {
                controller.Movement.Bounds = _prevArea.PlayArea;
                EnterGameArea(_prevArea, controller);
            }
            
        }

        private void EnterGameArea(GameAreaManager area,CharacterController controller)
        {
            controller.Area.CurrentArea.OnCharacterExited(controller);
            area.OnCharacterEntered(controller);
        }
    }
}

