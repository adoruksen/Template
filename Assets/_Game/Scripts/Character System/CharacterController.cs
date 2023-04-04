using Character.StateMachine;
using Sirenix.OdinInspector;
using InteractionSystem;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour,IInteractor
    {
        [SerializeReference, BoxGroup("Idle", false), HorizontalGroup("Idle/Group")] public State IdleState;
        [SerializeReference, BoxGroup("Game", false), HorizontalGroup("Game/Group")] public GameState GameState;
        [SerializeReference, BoxGroup("Death", false), HorizontalGroup("Death/Group")] public DeathState DeathState;
        [SerializeReference, BoxGroup("Enter", false), HorizontalGroup("Enter/Group")] public EnterBicycleState EnterBicycleState;
        [SerializeReference, BoxGroup("Bicycle", false), HorizontalGroup("Bicycle/Group")] public BicycleState BicycleState;
        [SerializeReference, BoxGroup("Exit", false), HorizontalGroup("Exit/Group")] public ExitBicycleState ExitBicycleState;

        [ShowInInspector,ReadOnly,BoxGroup("States",false)] public State CurrentState { get; private set; }


        public Rigidbody Rigidbody { get; private set; }
        public CharacterMovement Movement { get; private set; }
        public Interactor Interactor { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Movement = GetComponent<CharacterMovement>();
            Interactor = GetComponentInChildren<Interactor>();
            SetState(IdleState);
        }

        private void FixedUpdate()
        {
            CurrentState?.OnStateFixedUpdate(this);
        }

        public void ExitState()
        {
            CurrentState?.StateExit(this);
        }

        public void SetState(State newState)
        {
            ExitState();
            CurrentState = newState;
            CurrentState.StateEnter(this);
        }
    }
}

