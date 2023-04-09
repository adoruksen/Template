using System;
using InteractionSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Vehicle
{
    public class VehicleController : MonoBehaviour, IInteractor
    {
        public AnimatorOverrideController CharacterAnimator;
        public VehicleSeat Seat { get; private set; }
        public VehicleMovement Movement { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<VehicleMovement>();
            Seat = GetComponentInChildren<VehicleSeat>();
        }
    }
}

