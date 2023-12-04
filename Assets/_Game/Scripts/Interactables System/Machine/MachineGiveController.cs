using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using DG.Tweening;

namespace Interactables.Machine
{
    public class MachineGiveController : MonoBehaviour,IBeginInteract,IEndInteract,IStayInteract
    {
        private MachineController _controller;
        public bool IsInteractable { get; private set; } = true;

        private bool _characterIsTaking = false;

        [SerializeField] private GameObject _cube;
        private List<GameObject> cubeList = new();

        private float timer = 0f;


        private void Awake()
        {
            _controller = GetComponentInParent<MachineController>();
        }

        public void AddToList()
        {
            var myCube = Instantiate(_cube, transform);
            cubeList.Add(myCube);
            myCube.transform.localPosition = Vector3.up * cubeList.Count;
        }
        public void OnInteractBegin(IInteractor interactor)
        {
            _characterIsTaking = true;
        }

        public void OnInteractStay(IInteractor interactor)
        {
            if (!_characterIsTaking) return;
            var cooldown = 1f;
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                var obj = cubeList[^1];
                obj.transform.DOScale(Vector3.zero, .25f).OnComplete(() =>
                {
                    cubeList.Remove(obj);
                    timer = 0f;
                });
            }
        }

        public void OnInteractEnd(IInteractor interactor)
        {
            _characterIsTaking = false;
        }


    }
}

