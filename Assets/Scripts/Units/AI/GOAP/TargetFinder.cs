using RainesGames.Units.AI.GOAP.Actions;

namespace RainesGames.Units.AI.GOAP
{
    public class TargetFinder
    {
        // TODO Does every action need it's own TargetFinder?
        public UnitController DetermineTarget()
        {
            return AllUnitsManager.GetPlayerUnits()[0];
        }
    }
}