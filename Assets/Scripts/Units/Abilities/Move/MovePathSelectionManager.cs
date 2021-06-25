using RainesGames.Common;
using RainesGames.Grid;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class MovePathSelectionManager : MonoBehaviour, IUnitCellEvents
    {
        private IPathCondenser _pathCondenser;
        private IUnitPathProvider _pathProvider;
        private IPathTransitEvents _pathTransitResponse;
        private IPathWaypointManager _waypointManager;

        private bool _moving = false;

        void Awake()
        {
            _pathCondenser = GetComponent<IPathCondenser>();
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
        List<int> GetDrawPath(UnitController unit, int cellIndex, TerrainGridSystem sender)
        {
            return _pathProvider.GetPath(unit, _waypointManager.GetWaypoints(), cellIndex, sender);
        }

        /**
         * Returns the condensed path that the unit's NavMeshAgent will actually take when moving.
         */
        List<int> GetMovePath(UnitController unit, int cellIndex, TerrainGridSystem sender)
        {
            List<int> rawPath = _pathProvider.GetPath(unit, _waypointManager.GetWaypoints(), cellIndex, sender);
            return _pathCondenser.GetCondensedPath(sender, rawPath);
        }

        void HandleMoveClick(UnitController unit, int cellIndex, TerrainGridSystem sender)
        {
            OnUnitCellExit(unit, cellIndex, sender);

            unit.GetAbility<MoveAbility>().Execute(GetMovePath(unit, cellIndex, sender));

            _waypointManager.ClearWaypoints();
        }

        void HandleWaypointClick(UnitController unit, int cellIndex, TerrainGridSystem sender)
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

        public void OnUnitCellClick(UnitController unit, int cellIndex, TerrainGridSystem sender, int buttonIndex)
        {
            if(_moving)
                return;

            if(buttonIndex == 1)
            {
                HandleWaypointClick(unit, cellIndex, sender);
                return;
            }

            HandleMoveClick(unit, cellIndex, sender);
        }

        public void OnUnitCellEnter(UnitController unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_moving)
                return;

            _pathTransitResponse.OnPathEnter(
                sender,
                _waypointManager.GetWaypoints(),
                GetDrawPath(unit, cellIndex, sender)
            );
        }

        public void OnUnitCellExit(UnitController unit, int cellIndex, TerrainGridSystem sender)
        {
            if(_moving)
                return;

            _pathTransitResponse.OnPathExit(
                sender,
                _waypointManager.GetWaypoints(),
                GetDrawPath(unit, cellIndex, sender)
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
    }
}