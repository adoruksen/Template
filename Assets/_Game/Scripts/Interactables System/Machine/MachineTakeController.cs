using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using System;

namespace Interactables.Machine
{
    public class MachineTakeController : MonoBehaviour, IBeginInteract,IEndInteract,IStayInteract
    {
        private MachineController _controller;
        public bool IsInteractable { get; private set; } = true;

        private bool _characterIsGiving = false;

        private float timer = 0f;

        [SerializeField] private GameObject _cube;
        private List<GameObject> cubeList = new();

        public event Action<GameObject> OnCollected;



        private void Awake()
        {
            _controller = GetComponentInParent<MachineController>();
        }

        public void OnInteractBegin(IInteractor interactor)
        {
            _characterIsGiving = true;
        }

        public void OnInteractStay(IInteractor interactor)
        {
            if (!_characterIsGiving) return;
            var cooldown = 1f;
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                Debug.Log("Yaptým");
                var cubeObj = Instantiate(_cube, transform);
                cubeList.Add(cubeObj);
                cubeObj.transform.localPosition = Vector3.up * cubeList.Count;
                OnCollected?.Invoke(cubeObj);
                timer = 0f; 
            }

        }

        public void OnInteractEnd(IInteractor interactor)
        {
            _characterIsGiving = false;
        }


    }
}
