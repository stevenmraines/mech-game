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
        private List<AAction> _actions;
        private AGoal _currentGoal;
        private GoalFinder _goalFinder;
        private List<AGoal> _goals;
        private GoapStateManager _manager;
        private Queue<AAction> _plan;
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
            _actions = new List<AAction>(GetComponents<AAction>());
        }

        void LoadGoals()
        {
            _goals = new List<AGoal>(GetComponents<AGoal>());
        }

        public void SetCurrentGoal(AGoal goal)
        {
            _currentGoal = goal;
        }

        void Start()
        {
            _manager.TransitionToState(_manager.Idle);
        }
    }
}