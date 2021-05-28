using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.EnemyTurn
{
    public class Validator : TransitionValidator<CombatState>
    {
        public override bool ValidateTransition(CombatState nextState)
        {
            if(nextState.GetType() == typeof(PlayerTurnState))
                return PlayerTurn();

            return false;
        }

        bool PlayerTurn()
        {
            return UnitManager.AllEnemyActionPointsSpent();
        }
    }
}