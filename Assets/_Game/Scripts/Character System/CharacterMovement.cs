using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public float MoveSpeed;
        public bool IsActive;

        public bool UseBounds;
        public Bounds Bounds;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            if (!IsActive) return;

            var movement = direction * MoveSpeed;
            _rigidbody.velocity = movement;

            if (UseBounds) _rigidbody.position = Bounds.ClosestPoint(_rigidbody.position);
        }

        public void Look(Vector3 direction)
        {
            if (!IsActive) return;

            var rotation = Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(direction), .2f);
            _rigidbody.MoveRotation(rotation);
        }

        public void MoveToTarget(Vector3 target)
        {
            if (!IsActive) return;

            var offset = target - _rigidbody.position;
            var direction = offset.sqrMagnitude > 1 ? offset.normalized : offset;
            direction.y = 0f;

            Move(direction);
            Look(direction);
        }
    }
}

