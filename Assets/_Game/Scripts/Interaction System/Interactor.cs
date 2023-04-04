using Managers;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class Interactor : MonoBehaviour
    {
        private IInteractor _controller;
        private readonly List<IStayInteract> _stayInteractables = new List<IStayInteract>();
        public bool CanInteract;

        private void Awake()
        {
            _controller = GetComponentInParent<IInteractor>();
        }

        private void FixedUpdate()
        {
            if (!CanInteract || !GameManager.instance.IsPlaying) return;
            for (var i = 0; i < _stayInteractables.Count; i++)
            {
                if (!_stayInteractables[i].IsInteractable)
                {
                    _stayInteractables.RemoveAt(i);
                    continue;
                }

                _stayInteractables[i].OnInteractStay(_controller);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!CanInteract || !GameManager.instance.IsPlaying) return;
            if (!other.CompareTag(tag)) return;

            var hasStayInteractable = other.TryGetComponent<IStayInteract>(out var stayInteract);
            if (hasStayInteractable && stayInteract.IsInteractable) _stayInteractables.Add(stayInteract);

            var hasBeginInteractable = other.TryGetComponent<IBeginInteract>(out var interactable);
            if (hasBeginInteractable && interactable.IsInteractable) interactable.OnInteractBegin(_controller);

        }

        private void OnTriggerExit(Collider other)
        {
            if (!CanInteract || !GameManager.instance.IsPlaying) return;
            if (!other.CompareTag(tag)) return;

            var hasStayInteractable = other.TryGetComponent<IStayInteract>(out var stayInteract);
            if (hasStayInteractable && _stayInteractables.Contains(stayInteract))
                _stayInteractables.Remove(stayInteract);

            var hasEndInteractable = other.TryGetComponent<IEndInteract>(out var interactable);
            if (hasEndInteractable && interactable.IsInteractable) interactable.OnInteractEnd(_controller);
        }
    }
}

