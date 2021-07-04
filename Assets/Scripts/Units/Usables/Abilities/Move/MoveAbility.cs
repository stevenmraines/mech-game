using RainesGames.Grid;
using RainesGames.Units.Mechs;
using RainesGames.Units.States;
using System.Collections;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
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
        private Validator _validator = new Validator();

        public DataAbility Data;

        public delegate void MoveAbilityDelegate();
        public static event MoveAbilityDelegate OnMoveEnd;
        public static event MoveAbilityDelegate OnMoveStart;

        public override bool CanBeUsed()
        {
            return IsAffordable();
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
            if(_validator.IsValid(_parentUnit, path))
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

        public override int GetFirstAbilityCost()
        {
            return Data.FirstAbilityCost;
        }

        public override int GetSecondAbilityCost()
        {
            return Data.SecondAbilityCost;
        }

        public override AudioClip GetSoundEffect()
        {
            return Data.SoundEffect;
        }

        public override UnitState GetState()
        {
            return Data.State;
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

            _parentUnit.SetCell(path[path.Count - 1]);
            TransitionToIdle();
            OnMoveEnd?.Invoke();
            DecrementAbilityPoints();
        }

        void ResetPathIndex()
        {
            _pathIndex = 0;
        }

        void SetNavDestination(int cellIndex)
        {
            _navMeshAgent.SetDestination(GridWrapper.GetCellPosition(cellIndex));
        }

        public override bool ShowInTray()
        {
            return Data.ShowInTray;
        }

        void Start()
        {
            _navMeshAgent = ((MechController)_parentUnit).NavMeshAgent;
        }

        void TransitionToIdle()
        {
            ((MechController)_parentUnit).Animator.SetBool(_runningHash, false);
        }

        void TransitionToRun()
        {
            ((MechController)_parentUnit).Animator.SetBool(_runningHash, true);
        }
    }
}