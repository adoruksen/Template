using DG.Tweening;

namespace Character.StateMachine
{
    public class DeathState : State
    {

        protected override void OnStateEnter(CharacterController controller)
        {
            controller.DOKill();
            controller.Rigidbody.isKinematic = true;
            //ölme animasyonu
        }
    }
}

