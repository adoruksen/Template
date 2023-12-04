using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using System;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Interactables.Machine
{
    public class MachineController : MonoBehaviour
    {
        public MachineTakeController TakeController { get; private set; }
        public MachineGiveController GiveController { get; private set; }



        private void Awake()
        {
            TakeController = GetComponentInChildren<MachineTakeController>();
            GiveController = GetComponentInChildren<MachineGiveController>();
        }

        private void OnEnable()
        {
            TakeController.OnCollected += OnTakeHandler;
        }

        private void OnTakeHandler(GameObject gobject)
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                gobject.transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
                {
                    var giveObject = Instantiate(gobject, GiveController.transform);
                    GiveController.AddToList();
                });
            });
            
        }

        private void OnDisable()
        {
            TakeController.OnCollected -= OnTakeHandler;
        }

    }
}

