using System;
using Sirenix.OdinInspector;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;
using CharacterController = Character.CharacterController;


namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        public event Action OnCollected;

        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected Collider _collider;

        [SerializeField] protected float _verticalForce;
        [SerializeField] protected float _horizontalForce;

        protected virtual void Collect(CharacterController controller)
        {
            OnCollected?.Invoke();
            controller.StackController.AddStack(this);
            SetInteractable(false);
        }
        protected virtual void SetLost() //belki isinteractable true olmayabilir dikkat et.
        {
            transform.SetParent(GameManager.instance.defaultParent);
            SetInteractable(true);
            FlyingCollectable();
        }

        protected virtual void SetInteractable(bool interactable)
        {
            _collider.enabled = interactable;
            _rigidbody.isKinematic = !interactable;
        }

        protected void FlyingCollectable()
        {
            var force = Random.insideUnitCircle * _horizontalForce;
            force = new Vector3(force.x, Random.value * _verticalForce, force.y);
            _rigidbody.AddForce(force);
        }
    }
}

