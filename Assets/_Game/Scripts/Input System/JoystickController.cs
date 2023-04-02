using UnityEngine;

namespace InputSystem
{
    public class JoystickController : MonoBehaviour
    {
        public RectTransform joyStickObj;
        public RectTransform Knob;


        private void Awake()
        {
            joyStickObj = GetComponent<RectTransform>();
        }
    }

}

