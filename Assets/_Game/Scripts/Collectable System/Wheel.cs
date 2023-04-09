using InteractionSystem;
using UnityEngine;
using CharacterController = Character.CharacterController;


namespace Collectables
{
    public class Wheel : Collectable,IBeginInteract
    {
        public bool IsInteractable { get; private set; }

        public void OnInteractBegin(IInteractor interactor)
        {
            var controller = (CharacterController)interactor;
            Collect(controller);
        }

        protected override void SetInteractable(bool interactable)
        {
            base.SetInteractable(interactable);
            IsInteractable = false;
        }
    }
}

