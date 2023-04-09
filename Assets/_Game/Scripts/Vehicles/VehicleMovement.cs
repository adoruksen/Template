using UnityEngine;

namespace Vehicle
{
    public abstract class VehicleMovement : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public VehicleData Data;
        protected VehicleStats _stats;

        public float CurrentSpeed { get; protected set; }
        public Vector3 CurrentVelocity { get; protected set; }
        public float CurrentRotation { get; protected set; }
        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            SetStatsByGroundType(GroundType.Asphalt);
        }

        public void SetStatsByGroundType(GroundType type)
        {
            switch (type)
            {
                case GroundType.Asphalt:
                    _stats = Data.AsphaltStats;
                    break;
                case GroundType.Dirt:
                    _stats = Data.DirtStats;
                    break;
                case GroundType.Oil:
                    _stats = Data.OilStats;
                    break;
            }
        }

        public abstract void Accelerate();
        public abstract void Steer(float direction);
        public abstract void OnCollision(Collision other);
    }
}

