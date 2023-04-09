using UnityEngine;
using Collectables;

namespace GridSystem
{
    public class BicyclePartsGridObject : GridObject
    {
        private Collectable _collectable;

        private void Awake()
        {
            _collectable = GetComponent<Collectable>();
        }

        private void OnEnable()
        {
            _collectable.OnCollected += RemoveFromGrid;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _collectable.OnCollected -= RemoveFromGrid;
        }
    }
}

