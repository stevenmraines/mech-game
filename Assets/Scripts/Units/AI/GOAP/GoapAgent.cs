using RainesGames.Units.AI.GOAP.Actions;
using RainesGames.Units.AI.GOAP.Goals;
using RainesGames.Units.AI.GOAP.States;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.AI.GOAP
{
    [RequireComponent(typeof(GoapStateManager))]
    public class GoapAgent : MonoBehaviour
    {
        private List<Action> _actions;
        private Goal _currentGoal;
        private GoalFinder _goalFinder;
        private List<Goal> _goals;
        private GoapStateManager _manager;
        private Queue<Action> _plan;
        private Planner _planner;

        void Awake()
        {
            LoadActions();
            LoadGoals();
            _goalFinder = new GoalFinder();
            _manager = GetComponent<GoapStateManager>();
            _planner = new Planner();
        }

        void OnDisable()
        {
            IdleState.OnEnterState -= IdleOnEnterState;
        }
        
        void OnEnable()
        {
            IdleState.OnEnterState += IdleOnEnterState;
        }

        void GetPlan()
        {
            LoadActions();
            _plan = _planner.GetCheapestPlanForGoal(_currentGoal, _actions);
        }

        void IdleOnEnterState()
        {
            LoadGoals();
            SetCurrentGoal(_goalFinder.DetermineGoal(_goals));
        }

        void LoadActions()
        {
            _actions = new List<Action>(GetComponents<Action>());
        }

        void LoadGoals()
        {
            _goals = new List<Goal>(GetComponents<Goal>());
        }

        public void SetCurrentGoal(Goal goal)
        {
            _currentGoal = goal;
        }

        void Start()
        {
            _manager.TransitionToState(_manager.Idle);
        }
    }
}