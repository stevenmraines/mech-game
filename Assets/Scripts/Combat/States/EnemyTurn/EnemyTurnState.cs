namespace RainesGames.Combat.States.EnemyTurn
{
    public class EnemyTurnState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;

        protected override void Awake()
        {
            base.Awake();
            _stateName = "Enemy Turn";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
            
        }
    }
}