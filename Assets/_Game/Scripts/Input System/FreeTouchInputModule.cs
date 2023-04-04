using UnityEngine;

namespace InputSystem
{
    [CreateAssetMenu(menuName = "Game/Input/FreeTouch", order = -988)]
    public class FreeTouchInputModule : InputModule
    {
        public override void Update()
        {
            if (MouseDown)
            {
                _downPosition = MousePosition;
                _lastPosition = MousePosition;
                OnMouseDown?.Invoke(MousePosition);
            }

            if (MouseHold)
            {
                _delta = MousePosition - LastPosition;
                _delta *= Normalizer * Sensitivity;
                _offset = MousePosition - DownPosition;
                _offset *= Normalizer * Sensitivity;
                CheckMaxOffset();
                OnMouseHold?.Invoke(MousePosition);
            }

            if (MouseUp)
            {
                _delta = Vector2.zero;
                _offset = Vector2.zero;
                OnMouseUp?.Invoke(MousePosition);
            }

            _normalizedDelta = Vector2.ClampMagnitude(Delta / MaxOffset, 1f);
            _normalizedOffset = Offset / MaxOffset;
            _lastPosition = MousePosition;
        }

        private void CheckMaxOffset()
        {
            if (Offset.magnitude <= MaxOffset) return;

            _downPosition = MousePosition - Offset.normalized * MaxOffset;
            _offset = MousePosition - DownPosition;
        }
    }
}