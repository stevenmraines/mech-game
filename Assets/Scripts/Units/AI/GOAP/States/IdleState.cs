namespace RainesGames.Units.AI.GOAP.States
{
    public class IdleState : GoapState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
        }

        public override void UpdateState() { }
    }
}