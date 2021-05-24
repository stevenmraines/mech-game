using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.PlayerPlacement
{
    public class Validator : TransitionValidator<CombatState>
    {
        public override bool ValidateTransition(CombatState state)
        {
            if(state.GetType() == typeof(EnemyPlacementState))
                return EnemyPlacement();

            return false;
        }

        bool EnemyPlacement()
        {
            return UnitManager.AllPlayerUnitsPlaced();
        }
    }
}