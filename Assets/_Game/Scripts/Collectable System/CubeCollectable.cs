using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using CharacterController = Character.CharacterController;

namespace Collectables
{
    public class CubeCollectable : Collectable, IBeginInteract
    {
        public bool IsInteractable { get; private set; } = true;

        public void OnInteractBegin(IInteractor interactor)
        {
            var character = (CharacterController)interactor;
            character.StackController.AddStack(this);
        }
    }
}

