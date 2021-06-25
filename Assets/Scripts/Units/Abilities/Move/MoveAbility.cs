using RainesGames.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units.Abilities.Move
{
    [DisallowMultipleComponent]
    public class MoveAbility : AbsAbility, IPathTargetAbility
    {
        private NavMeshAgent _navMeshAgent;
        private int _pathIndex = 0;
        private int _runningHash = Animator.StringToHash("Running");
        private Validator _validator;

        public delegate void MoveAbilityDelegate();
        public static event MoveAbilityDelegate OnMoveEnd;
        public static event MoveAbilityDelegate OnMoveStart;

        void Awake()
        {
            _firstAbilityCost = 1;
            _secondAbilityCost = 1;
            _showInTray = false;
            _validator = new Validator();
        }
        
        // TODO Move all this NavMeshAgent helper stuff into some separate class
        bool DestinationReached()
        {
            bool pathPending = _navMeshAgent.pathPending;
            bool distanceClosed = _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
            bool hasPath = _navMeshAgent.hasPath;
            bool notMoving = _navMeshAgent.velocity.sqrMagnitude == 0;
            bool nowhereToGo = !hasPath || notMoving;
            return !pathPending && distanceClosed && nowhereToGo;
        }

        public void Execute(List<int> path)
        {
            if(_validator.IsValid(_controller, path))
            {
                ResetPathIndex();
                StartCoroutine(Move(path));
            }
        }

        bool FinalDestinationReached(List<int> path)
        {
            return FinalDestinationIsSet(path) && DestinationReached();
        }

        bool FinalDestinationIsSet(List<int> path)
        {
            return _pathIndex == path.Count - 1;
        }

        IEnumerator Move(List<int> path)
        {
            OnMoveStart?.Invoke();
            TransitionToRun();
            SetNavDestination(path[_pathIndex]);

            while(!FinalDestinationReached(path))
            {
                if(DestinationReached() && !FinalDestinationIsSet(path))
                {
                    _pathIndex++;
                    SetNavDestination(path[_pathIndex]);
                }
                
                yield return new WaitForSecondsRealtime(.05f);
            }

            _controller.PositionManager.SetCell(path[path.Count - 1]);
            DecrementAbilityPoints();
            TransitionToIdle();
            OnMoveEnd?.Invoke();
        }

        void ResetPathIndex()
        {
            _pathIndex = 0;
        }

        void SetNavDestination(int cellIndex)
        {
            _navMeshAgent.SetDestination(GridWrapper.GetCellPosition(cellIndex));
        }

        protected override void Start()
        {
            base.Start();
            _state = _controller.StateManager.Move;
            _navMeshAgent = _controller.NavMeshAgent;
        }

        void TransitionToIdle()
        {
            _controller.Animator.SetBool(_runningHash, false);
        }

        void TransitionToRun()
        {
            _controller.Animator.SetBool(_runningHash, true);
        }
    }
}