namespace RainesGames.Combat.States.EnemyTurn
{
    public class EnemyTurnState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;

        protected override void Awake()
        {
            base.Awake();
            StateName = "Enemy Turn";
        }

        public override void EnterState()
        {
            OnEnterState?.Invoke();
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
    }
}