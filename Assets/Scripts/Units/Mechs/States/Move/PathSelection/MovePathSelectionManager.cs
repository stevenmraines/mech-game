using RainesGames.Common;
using RainesGames.Grid;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities.Move;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Mechs.States.Move.PathSelection
{
    public class MovePathSelectionManager : MonoBehaviour, IUnitCellEvents
    {
        private IUnitPathCondenser _pathCondenser;
        private IUnitPathProvider _pathProvider;
        private IPathTransitEvents _pathTransitResponse;
        private IPathWaypointManager _waypointManager;

        private bool _moving = false;

        void Awake()
        {
            _pathCondenser = GetComponent<IUnitPathCondenser>();
            _pathProvider = GetComponent<IUnitPathProvider>();
            _pathTransitResponse = GetComponent<IPathTransitEvents>();
            _waypointManager = GetComponent<IPathWaypointManager>();
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
            OnUnitCellExit(unit, cellIndex, sender);

            unit.GetUsable<MoveAbility>().Use(GetMovePath(unit, cellIndex, sender));

            _waypointManager.ClearWaypoints();
        }

        void HandleWaypointClick(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_waypointManager.WaypointIsSet(cellIndex))
            {
                OnUnitCellExit(unit, cellIndex, sender);
                _waypointManager.RemoveWaypoint(cellIndex);
                OnUnitCellEnter(unit, cellIndex, sender);
                return;
            }

            _waypointManager.AddWaypoint(cellIndex);
        }

        public void OnUnitCellClick(IUnit unit, int cellIndex, TerrainGridSystem sender, int buttonIndex)
        {
            if(_moving)
                return;

            if(PathIsTooLong(unit, GetDrawPath(unit, cellIndex, sender)))
                return;

            if(buttonIndex == 1)
            {
                HandleWaypointClick(unit, cellIndex, sender);
                return;
            }

            HandleMoveClick(unit, cellIndex, sender);
        }

        public void OnUnitCellEnter(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_moving)
                return;

            IList<int> drawPath = GetDrawPath(unit, cellIndex, sender);

            if(PathIsTooLong(unit, drawPath))
                return;

            _pathTransitResponse.OnPathEnter(
                sender,
                _waypointManager.GetWaypoints(),
                drawPath
            );
        }

        public void OnUnitCellExit(IUnit unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_moving)
                return;

            IList<int> drawPath = GetDrawPath(unit, cellIndex, sender);

            if(PathIsTooLong(unit, drawPath))
                return;

            _pathTransitResponse.OnPathExit(
                sender,
                _waypointManager.GetWaypoints(),
                drawPath
            );
        }

        void OnDisable()
        {
            MoveAbility.OnMoveEnd -= EnableUserInteraction;
            MoveAbility.OnMoveStart -= DisableUserInteraction;
        }

        void OnEnable()
        {
            MoveAbility.OnMoveEnd += EnableUserInteraction;
            MoveAbility.OnMoveStart += DisableUserInteraction;
        }

        bool PathIsTooLong(IUnit unit, ICollection<int> path)
        {
            return path.Count > ((MechController)unit).GetMovement();
        }
    }
}