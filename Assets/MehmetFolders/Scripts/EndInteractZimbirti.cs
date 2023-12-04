using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using CharacterController = Character.CharacterController;

public class EndInteractZimbirti : IEndInteract
{
    public bool IsInteractable { get; private set; } = true;

    public void OnInteractEnd(IInteractor interactor)
    {
        var character = (CharacterController)interactor;
        Debug.Log("End madafakiniggaBitch");
    }
}
