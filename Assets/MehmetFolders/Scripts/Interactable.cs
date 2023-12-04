using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CharacterController = Character.CharacterController;

public abstract class Interactable : MonoBehaviour
{
    public event Action OnInteract;

    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Collider _collider;

    protected virtual void Interact(CharacterController controller)
    {
        OnInteract?.Invoke();
    }
}
