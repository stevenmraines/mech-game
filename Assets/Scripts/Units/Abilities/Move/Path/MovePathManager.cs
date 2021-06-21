using RainesGames.Common;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move.Path
{
    public class MovePathManager : MonoBehaviour, ICellEvents
    {
        [SerializeField] private ICellSelectionResponse _cellSelectionResponse;
        [SerializeField] private IPathConfirmationResponse _pathConfirmationResponse;
        [SerializeField] private IPathProvider _pathProvider;
        [SerializeField] private IWaypointPlacementResponse _waypointPlacementResponse;

        private List<int> _path;
        public List<int> Path => _path;

        private List<int> _waypoints;
        public List<int> Waypoints => _waypoints;

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            _cellSelectionResponse.OnSelect(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            _cellSelectionResponse.OnDeselect(sender, cellIndex);
        }
    }
}