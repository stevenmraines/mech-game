namespace RainesGames.Combat.States.PlayerLost
{
    public class PlayerLostState : CombatState
    {
        protected override void Awake()
        {
            base.Awake();
            _stateName = "Player Lost";
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