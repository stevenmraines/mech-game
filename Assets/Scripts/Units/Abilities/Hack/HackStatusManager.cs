using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;

namespace RainesGames.Units.Abilities.Hack
{
    public class HackStatusManager : AStatusManager
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

        public override void Activate()
        {
            base.Activate();
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