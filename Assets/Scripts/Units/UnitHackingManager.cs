using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;

namespace RainesGames.Units
{
    public class UnitHackingManager : ATempStatusManager
    {
        public const int HACK_DURATION = 4;

        public UnitHackingManager(UnitController controller) : base(controller)
        {
            EnemyTurnState.OnExitState += OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState += OnExitStatePlayerTurn;
        }

        ~UnitHackingManager()
        {
            EnemyTurnState.OnExitState -= OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState -= OnExitStatePlayerTurn;
        }

        protected override void Countdown()
        {
            if(!_active)
                return;

            _turnsRemaining--;

            if(_turnsRemaining == 0)
                _active = false;
        }

        public void Hack()
        {
            _active = true;
            _turnsRemaining = HACK_DURATION;

            // TODO do this with an event?
            _controller.ActionPointsManager.ForceSpendAllActionPoints();
        }

        void OnExitStateEnemyTurn()
        {
            if(_controller.HasPlayerTag())
                Countdown();
        }

        void OnExitStatePlayerTurn()
        {
            if(_controller.HasEnemyTag())
                Countdown();
        }
    }
}