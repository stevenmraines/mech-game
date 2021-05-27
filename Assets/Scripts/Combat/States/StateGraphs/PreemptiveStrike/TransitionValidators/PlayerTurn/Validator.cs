using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.PlayerTurn
{
    public class Validator : TransitionValidator<CombatState>
    {
        public override bool ValidateTransition(CombatState state)
        {
            if(state.GetType() == typeof(EnemyTurnState))
                return EnemyTurn();

            return false;
        }

        bool EnemyTurn()
        {
            return UnitManager.AllPlayerActionPointsSpent();
        }
    }
}