using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LevelObjectsSystem
{
    public class StackFillArea : MonoBehaviour
    {
        public event Action<int> OnAdded;
        public event Action OnCompleted;

        [ShowInInspector, ReadOnly] private int _size;

        public bool Filled { get; private set; }
        public int Size => _size;

        public void SetSize(int size)
        {
            _size = size;
        }

        public void AddStack()
        {
            for (int i = 0; i < Size; i++)
            {
                SetGridTeam(i);
            }
        }

        private void SetGridTeam(int i)
        {
            OnAdded?.Invoke(i);

            if (i < Size - 1) return;

            Filled = true;
            OnCompleted?.Invoke();
        }
    }
}

