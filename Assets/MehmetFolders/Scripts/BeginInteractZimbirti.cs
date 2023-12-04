using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using CharacterController = Character.CharacterController;

public class BeginInteractZimbirti : IBeginInteract
{
    public bool IsInteractable { get; private set; } = true;

    public void OnInteractBegin(IInteractor interactor)
    {
        var character = (CharacterController)interactor;
        Debug.Log("Begin madafakiniggaBitch");
    }
}
