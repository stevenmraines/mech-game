using System.Collections;
using System.Collections.Generic;
using RainesGames.Grid;
using RainesGames.Units.Mechs;
using RainesGames.Units.States;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units.Usables.Abilities.Move
{
    [DisallowMultipleComponent]
    public class MoveAbility : AbsUsable, IAbility, IPathTargetUsable
    {
        private NavMeshAgent _navMeshAgent;
        private int _pathIndex = 0;
        private int _runningHash = Animator.StringToHash("Running");
        private Validator _validator = new Validator();

        public DataAbility AbilityData;
        public DataUsable UsableData;

        public delegate void MoveAbilityDelegate();
        public static event MoveAbilityDelegate OnMoveEnd;
        public static event MoveAbilityDelegate OnMoveStart;

        public override bool CanBeUsed()
        {
            return IsAffordable();
        }

        public void Use(IList<int> path)
        {
            if(_validator.IsValidTarget(_unit, path))
            {
                ResetPathIndex();
                StartCoroutine(Move(path));
            }
        }


        #region ABILITY DATA METHODS
        public AudioClip GetSoundEffect()
        {
            return AbilityData.SoundEffect;
        }
        #endregion


        #region MOVE METHODS
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

        bool FinalDestinationReached(IList<int> path)
        {
            return FinalDestinationIsSet(path) && DestinationReached();
        }

        bool FinalDestinationIsSet(IList<int> path)
        {
            return _pathIndex == path.Count - 1;
        }

        IEnumerator Move(IList<int> path)
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

            _unit.SetCell(path[path.Count - 1]);
            TransitionToIdle();
            OnMoveEnd?.Invoke();
            DecrementActionPoints();
        }

        void ResetPathIndex()
        {
            _pathIndex = 0;
        }

        void SetNavDestination(int cellIndex)
        {
            _navMeshAgent.SetDestination(GridWrapper.GetCellPosition(cellIndex));
        }

        void Start()
        {
            _navMeshAgent = ((MechController)_unit).NavMeshAgent;
        }

        void TransitionToIdle()
        {
            ((MechController)_unit).Animator.SetBool(_runningHash, false);
        }

        void TransitionToRun()
        {
            ((MechController)_unit).Animator.SetBool(_runningHash, true);
        }
        #endregion


        #region USABLE DATA METHODS
        public override int GetFirstActionCost()
        {
            return UsableData.FirstActionCost;
        }

        public override string GetName()
        {
            return UsableData.UsableName;
        }

        public override int GetSecondActionCost()
        {
            return UsableData.SecondActionCost;
        }

        public override UnitState GetState()
        {
            return UsableData.State;
        }

        public override bool ShowInTray()
        {
            return UsableData.ShowInTray;
        }
        #endregion
    }
}