namespace RainesGames.Units.AI.GOAP.States
{
    public class IdleState : AGoapState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;

        public override void EnterState()
        {
            OnEnterState?.Invoke();
        }

        public override void ExitState() { }
        
        public override void UpdateState() { }
    }
}