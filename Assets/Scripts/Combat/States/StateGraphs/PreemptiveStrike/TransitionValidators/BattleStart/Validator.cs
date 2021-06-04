using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Common.States;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.BattleStart
{
    public class Validator : ITransitionValidator
    {
        public bool IsValid(IState nextState)
        {
            if(nextState.GetType() == typeof(PlayerPlacementState))
                return PlayerPlacement();

            return false;
        }

        bool PlayerPlacement()
        {
            return true;
        }
    }
}