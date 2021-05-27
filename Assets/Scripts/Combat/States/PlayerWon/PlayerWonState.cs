namespace RainesGames.Combat.States.PlayerWon
{
    public class PlayerWonState : CombatState
    {
        protected override void Awake()
        {
            base.Awake();
            _stateName = "Player Won";
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
            
        }
    }
}