using System;

namespace Character.StateMachine
{
    [Serializable]
    public abstract class State
    {
        public event Action<CharacterController> OnStateEntered;
        public event Action<CharacterController> OnStatedExited;

        protected virtual void OnStateEnter(CharacterController controller) { }
        public virtual void OnStateFixedUpdate(CharacterController controller) { }
        protected virtual void OnStateExit(CharacterController controller) { }

        public void StateEnter(CharacterController controller)
        {
            OnStateEnter(controller);
            OnStateEntered?.Invoke(controller);
        }

        public void StateExit(CharacterController controller)
        {
            OnStateExit(controller);
            OnStatedExited?.Invoke(controller);
        }

    }
}

