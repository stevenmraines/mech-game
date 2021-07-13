using System.Collections.Generic;
using RainesGames.Grid;
using RainesGames.Grid.Selection;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public class ColorizePathResponse : IPathTransitEvents
    {
        void ColorizeCells(TerrainGridSystem sender, IList<int> cells, Color color)
        {
            foreach(int cellIndex in cells)
                GridWrapper.SetCellColor(cellIndex, color);
        }

        public void OnPathEnter(TerrainGridSystem sender, IList<int> waypoints, IList<int> path)
        {
            ColorizeCells(sender, path, Color.blue);
            ColorizeCells(sender, waypoints, Color.cyan);
        }

        public void OnPathExit(TerrainGridSystem sender, IList<int> waypoints, IList<int> path)
        {
            ColorizeCells(sender, path, CellSelectionManager.DefaultCellColor);
        }
    }
}