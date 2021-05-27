namespace RainesGames.Units.States
{
    public class IdleState : UnitState
    {
        public override void Awake()
        {
            base.Awake();
            _stateName = "Idle";
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
            if(!_entered)
                return;
        }
    }
}