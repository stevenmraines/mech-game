using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;

namespace RainesGames.Units.Abilities.Hack
{
    public class HackStatusManager : ATempStatusManager
    {
        public HackStatusManager(UnitController controller) : base(controller)
        {
            _statusDuration = 4;

            EnemyTurnState.OnExitState += OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState += OnExitStatePlayerTurn;
        }

        ~HackStatusManager()
        {
            EnemyTurnState.OnExitState -= OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState -= OnExitStatePlayerTurn;
        }

        public void Hack()
        {
            _active = true;
            _turnsRemaining = _statusDuration;

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