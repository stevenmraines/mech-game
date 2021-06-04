﻿using RainesGames.Units.AI.GOAP.Actions;
using RainesGames.Units.AI.GOAP.Goals;
using System.Collections.Generic;

namespace RainesGames.Units.AI.GOAP
{
    public class Planner
    {
        public Queue<Action> GetCheapestPlanForGoal(Goal goal, List<Action> actions)
        {
            Queue<Action> plan = new Queue<Action>();

            foreach(Action action in actions)
            {
                foreach(KeyValuePair<string, object> effectBool in action.Effects)
                {
                    // TODO how to check preconditions?
                    if(effectBool.Key.CompareTo(goal.DesiredEffect) == 0 && (bool)effectBool.Value)
                        plan.Enqueue(action);
                }
            }

            return plan;
        }
    }
}