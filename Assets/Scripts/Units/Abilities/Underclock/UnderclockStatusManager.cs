using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;

namespace RainesGames.Units.Abilities.Underclock
{
    public class UnderclockStatusManager : AStatusManager
    {
        public UnderclockStatusManager(UnitController controller) : base(controller)
        {
            EnemyTurnState.OnExitState += OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState += OnExitStatePlayerTurn;
        }

        ~UnderclockStatusManager()
        {
            EnemyTurnState.OnExitState -= OnExitStateEnemyTurn;
            PlayerTurnState.OnExitState -= OnExitStatePlayerTurn;
        }

        void OnExitStateEnemyTurn()
        {
            if(_controller.IsEnemy())
                Countdown();
        }

        void OnExitStatePlayerTurn()
        {
            if(_controller.IsPlayer())
                Countdown();
        }
    }
}