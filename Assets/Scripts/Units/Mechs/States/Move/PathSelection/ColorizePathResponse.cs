using RainesGames.Grid;
using RainesGames.Grid.Selection;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Mechs.States.Move.PathSelection
{
    public class ColorizePathResponse : MonoBehaviour, IPathTransitEvents
    {
        void ColorizeCells(TerrainGridSystem sender, List<int> cells, Color color)
        {
            foreach(int cellIndex in cells)
                GridWrapper.SetColor(cellIndex, color);
        }

        public void OnPathEnter(TerrainGridSystem sender, List<int> waypoints, List<int> path)
        {
            ColorizeCells(sender, path, Color.blue);
            ColorizeCells(sender, waypoints, Color.cyan);
        }

        public void OnPathExit(TerrainGridSystem sender, List<int> waypoints, List<int> path)
        {
            ColorizeCells(sender, path, CellSelectionManager.DefaultCellColor);
        }
    }
}