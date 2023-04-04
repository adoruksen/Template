namespace Character.StateMachine
{
    public class GameState : State
    {
        protected override void OnStateEnter(CharacterController controller)
        {
            controller.Movement.UseBounds = true;
        }

        protected override void OnStateExit(CharacterController controller)
        {
            controller.Movement.UseBounds = false;
        }
    }
}


