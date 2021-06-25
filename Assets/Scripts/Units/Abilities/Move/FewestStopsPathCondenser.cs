using RainesGames.Grid;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class FewestStopsPathCondenser : MonoBehaviour, IPathCondenser
    {
        public enum AdjacentCellConfiguration
        {
            DIAGONAL_NORTH_EAST,
            DIAGONAL_NORTH_WEST,
            DIAGONAL_SOUTH_EAST,
            DIAGONAL_SOUTH_WEST,
            NOT_ADJACENT,
            SAME_COLUMN,
            SAME_ROW
        };

        bool DiagonalNorthEast(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == sender.rowCount + 1;
        }

        bool DiagonalNorthWest(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == sender.rowCount - 1;
        }

        bool DiagonalSouthEast(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == sender.columnCount + 1;
        }

        bool DiagonalSouthWest(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == sender.columnCount - 1;
        }

        bool SameColumn(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == sender.rowCount;
        }

        bool SameRow(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == 1;
        }

        AdjacentCellConfiguration GetCellConfiguration(TerrainGridSystem sender, int cellIndex1, int cellIndex2)
        {
            if(DiagonalNorthEast(sender, cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_NORTH_EAST;

            if(DiagonalNorthWest(sender, cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_NORTH_WEST;

            if(DiagonalSouthEast(sender, cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_SOUTH_EAST;

            if(DiagonalSouthWest(sender, cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_SOUTH_WEST;

            if(SameColumn(sender, cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.SAME_COLUMN;

            if(SameRow(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.SAME_ROW;

            return AdjacentCellConfiguration.NOT_ADJACENT;
        }

        public List<int> GetCondensedPath(TerrainGridSystem sender, List<int> path)
        {
            if(path.Count < 2)
                return path;

            List<int> condensedPath = new List<int>();

            AdjacentCellConfiguration configuration = GetCellConfiguration(sender, path[0], path[1]);

            // Something went wrong, just return the original path and get out of here
            if(configuration == AdjacentCellConfiguration.NOT_ADJACENT)
                return path;

            AdjacentCellConfiguration previousConfiguration;

            for(int i = 1; i < path.Count - 1; i++)
            {
                previousConfiguration = configuration;
                configuration = GetCellConfiguration(sender, path[i], path[i + 1]);

                if(configuration == AdjacentCellConfiguration.NOT_ADJACENT)
                    return path;

                if(configuration != previousConfiguration)
                    condensedPath.Add(path[i]);
            }

            // Make sure the final cell is added no matter what
            if(!condensedPath.Contains(path[path.Count - 1]))
                condensedPath.Add(path[path.Count - 1]);

            // TODO Return a list of UNIQUE cell indices
            return condensedPath;
        }
    }
}