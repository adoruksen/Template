using Character.StateMachine;
using StackSystem;
using Vehicle;
using Sirenix.OdinInspector;
using InteractionSystem;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour,IInteractor
    {
        [SerializeReference, BoxGroup("Idle", false), HorizontalGroup("Idle/Group")] public State IdleState;
        [SerializeReference, BoxGroup("Game", false), HorizontalGroup("Game/Group")] public GameState GameState;
        [SerializeReference, BoxGroup("Stack", false), HorizontalGroup("Stack/Group")] public StackState StackState;
        [SerializeReference, BoxGroup("Death", false), HorizontalGroup("Death/Group")] public DeathState DeathState;
        [SerializeReference, BoxGroup("Enter", false), HorizontalGroup("Enter/Group")] public EnterVehicleState EnterVehicleState;
        [SerializeReference, BoxGroup("Drive", false), HorizontalGroup("Drive/Group")] public DriveState DriveState;
        [SerializeReference, BoxGroup("Exit", false), HorizontalGroup("Exit/Group")] public ExitVehicleState ExitVehicleState;

        [ShowInInspector,ReadOnly,BoxGroup("States",false)] public State CurrentState { get; private set; }


        public Rigidbody Rigidbody { get; private set; }
        public CharacterMovement Movement { get; private set; }
        public CharacterAnimationController Animation { get; private set; }
        public CharacterArea Area { get; private set; }
        public Interactor Interactor { get; private set; }
        public StackController StackController { get; private set; }
        public VehicleController Vehicle;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Movement = GetComponent<CharacterMovement>();
            Animation = GetComponent<CharacterAnimationController>();
            Area = GetComponent<CharacterArea>();
            Interactor = GetComponentInChildren<Interactor>();
            StackController = GetComponent<StackController>();
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

