using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.PlayerTurn
{
    public class Validator : ITransitionValidator
    {
        public bool IsValid(IState nextState)
        {
            if(nextState.GetType() == typeof(EnemyTurnState))
                return EnemyTurn();

            return false;
        }

        bool EnemyTurn()
        {
            return AllUnitsManager.AllPlayerActionPointsSpent();
        }
    }
}