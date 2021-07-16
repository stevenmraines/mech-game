using System.Collections;
using System.Collections.Generic;
using RainesGames.Combat.States;
using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units.Mechs;
using TGS;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units.Usables.Abilities.Move
{
    [DisallowMultipleComponent]
    public class MoveAbility : AbsUsable, IAbility, IActiveCellEvents, IDeactivatableUsable, IPathTargetUsable
    {
        private bool _moving = false;
        private NavMeshAgent _navMeshAgent;
        private IUnitPathCondenser _pathCondenser;
        private int _pathIndex = 0;
        private IUnitPathProvider _pathProvider;
        private IPathTransitEvents _pathTransitResponse;
        private IList<int> _previousPath = new List<int>();
        private int _runningHash = Animator.StringToHash("Running");
        private IPathTargetUsableValidator _validator = new MoveValidator();
        private IPathWaypointManager _waypointManager;

        public DataAbility AbilityData;
        public DataUsable UsableData;


        #region MONOBEHAVIOUR METHODS
        protected override void Awake()
        {
            base.Awake();
            _pathCondenser = new FewestStopsPathCondenser();
            _pathProvider = new JoinedWaypointsPathProvider();
            _pathTransitResponse = new ColorizePathResponse();
            _waypointManager = new WaypointManager();
        }

        void OnDisable()
        {
            CellEventRouter.OnCellClickReroute -= OnActiveCellClick;
            CellEventRouter.OnCellEnterReroute -= OnActiveCellEnter;
            CellEventRouter.OnCellExitReroute -= OnActiveCellExit;
        }

        void OnEnable()
        {
            CellEventRouter.OnCellClickReroute += OnActiveCellClick;
            CellEventRouter.OnCellEnterReroute += OnActiveCellEnter;
            CellEventRouter.OnCellExitReroute += OnActiveCellExit;
        }

        void Start()
        {
            _navMeshAgent = ((MechController)_unit).NavMeshAgent;
        }
        #endregion


        #region MISC METHODS
        public void Deactivate()
        {
            _pathTransitResponse.OnPathExit(GridWrapper.TerrainGridSystem, new List<int>(), _previousPath);
        }

        void DisableUserInteraction()
        {
            _moving = true;
        }

        void EnableUserInteraction()
        {
            _moving = false;
        }

        /**
         * Returns the complete, uncondensed path used for drawing/painting cells on the grid.
         */
        IList<int> GetDrawPath(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            return _pathProvider.GetPath(unit, _waypointManager.GetWaypoints(), cellIndex, sender);
        }

        /**
         * Returns the condensed path that the unit's NavMeshAgent will actually take when moving.
         */
        IList<int> GetMovePath(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            IList<int> rawPath = _pathProvider.GetPath(unit, _waypointManager.GetWaypoints(), cellIndex, sender);
            return _pathCondenser.GetCondensedPath(unit, rawPath, sender);
        }

        void HandleMoveClick(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            OnActiveCellExit(unit, cellIndex, sender);

            unit.GetUsable<MoveAbility>().Use(GetMovePath(unit, cellIndex, sender));

            _waypointManager.ClearWaypoints();
        }

        void HandleWaypointClick(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_waypointManager.WaypointIsSet(cellIndex))
            {
                OnActiveCellExit(unit, cellIndex, sender);
                _waypointManager.RemoveWaypoint(cellIndex);
                OnActiveCellEnter(unit, cellIndex, sender);
                return;
            }

            _waypointManager.AddWaypoint(cellIndex);
        }

        bool IsValidCell(IUnit activeUnit, int cellIndex)
        {
            return !GridWrapper.IsBlocked(cellIndex) && cellIndex != activeUnit.GetPosition().index;
        }

        bool PathIsTooLong(IUnit unit, ICollection<int> path)
        {
            return path.Count > ((MechController)unit).GetMovement();
        }

        public void Use(IList<int> path)
        {
            if(_validator.IsValid(_unit, path))
            {
                ResetPathIndex();
                StartCoroutine(Move(path));
            }
        }
        #endregion


        #region ABILITY DATA METHODS
        public AudioClip GetSoundEffect()
        {
            return AbilityData.SoundEffect;
        }
        #endregion


        #region CELL EVENTS
        public void OnActiveCellClick(IUnit activeUnit, int cellIndex, TerrainGridSystem sender, int buttonIndex)
        {
            if(!IsValidCell(activeUnit, cellIndex))
                return;

            if(!ShouldHandleEvent(activeUnit))
                return;

            if(_moving)
                return;

            if(PathIsTooLong(activeUnit, GetDrawPath(activeUnit, cellIndex, sender)))
                return;

            if(buttonIndex == 1)
            {
                HandleWaypointClick(activeUnit, cellIndex, sender);
                return;
            }

            HandleMoveClick(activeUnit, cellIndex, sender);
        }

        public void OnActiveCellEnter(IUnit activeUnit, int cellIndex, TerrainGridSystem sender)
        {
            if(!IsValidCell(activeUnit, cellIndex))
                return;

            if(!ShouldHandleEvent(activeUnit))
                return;

            if(_moving)
                return;

            IList<int> drawPath = GetDrawPath(activeUnit, cellIndex, sender);

            if(PathIsTooLong(activeUnit, drawPath))
                return;

            _previousPath = drawPath;

            _pathTransitResponse.OnPathEnter(
                sender,
                _waypointManager.GetWaypoints(),
                drawPath
            );
        }

        public void OnActiveCellExit(IUnit activeUnit, int cellIndex, TerrainGridSystem sender)
        {
            if(!IsValidCell(activeUnit, cellIndex))
                return;

            if(!ShouldHandleEvent(activeUnit))
                return;

            if(_moving)
                return;

            IList<int> drawPath = GetDrawPath(activeUnit, cellIndex, sender);

            if(PathIsTooLong(activeUnit, drawPath))
                return;

            _pathTransitResponse.OnPathExit(
                sender,
                _waypointManager.GetWaypoints(),
                drawPath
            );
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
            DisableUserInteraction();
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
            EnableUserInteraction();
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

        public override bool NeedsLOS()
        {
            return UsableData.NeedsLOS;
        }

        public override bool ShowInTray()
        {
            return UsableData.ShowInTray;
        }
        #endregion
    }
}