using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.PlayerPlacement
{
    public class Validator : ITransitionValidator
    {
        public bool IsValid(IState nextState)
        {
            if(nextState.GetType() == typeof(EnemyPlacementState))
                return EnemyPlacement();

            return false;
        }

        bool EnemyPlacement()
        {
            return UnitManager.AllPlayerUnitsPlaced();
        }
    }
}