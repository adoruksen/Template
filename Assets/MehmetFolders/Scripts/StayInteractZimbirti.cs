using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using CharacterController = Character.CharacterController;


public class StayInteractZimbirti :  IStayInteract
{
    public bool IsInteractable { get; private set; } = true;

    public void OnInteractStay(IInteractor interactor)
    {
        var character = (CharacterController)interactor;
        Debug.Log("Stay madafakiniggaBitch");
    }
}
