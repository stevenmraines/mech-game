using RainesGames.Units.AI.GOAP.Goals;
using System.Collections.Generic;

namespace RainesGames.Units.AI.GOAP
{
    public class GoalFinder
    {
        public AGoal DetermineGoal(List<AGoal> goals)
        {
            return goals[0];
        }
    }
}