using RainesGames.Units.AI.GOAP.Goals;
using System.Collections.Generic;

namespace RainesGames.Units.AI.GOAP
{
    public class GoalFinder
    {
        public Goal DetermineGoal(List<Goal> goals)
        {
            return goals[0];
        }
    }
}