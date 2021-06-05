using RainesGames.Common;
using RainesGames.Common.States;
using RainesGames.Grid;
using RainesGames.Grid.Selection;
using TGS;

namespace RainesGames.Combat.States
{
    public class CellEventRouter : IStateEventRouter, ICellEvents
    {
        private CombatStateManager _manager;

        public delegate void CellClickDelegate(TerrainGridSystem sender, int cellIndex, int buttonIndex);
        public static event CellClickDelegate OnCellClickReroute;
        
        public delegate void CellMouseEventDelegate(TerrainGridSystem sender, int cellIndex);
        public static event CellMouseEventDelegate OnCellEnterReroute;
        public static event CellMouseEventDelegate OnCellExitReroute;

        public CellEventRouter(CombatStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            GridSelectionManager.OnCellClick -= OnCellClick;
            GridManager.TerrainGridSystem.OnCellEnter -= OnCellEnter;
            GridManager.TerrainGridSystem.OnCellExit -= OnCellExit;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellEnter(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellExit(sender, cellIndex);
        }

        public void RegisterEventHandlers()
        {
            GridSelectionManager.OnCellClick += OnCellClick;
            GridManager.TerrainGridSystem.OnCellEnter += OnCellEnter;
            GridManager.TerrainGridSystem.OnCellExit += OnCellExit;
        }

        public void RerouteCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            OnCellClickReroute?.Invoke(sender, cellIndex, buttonIndex);
        }

        public void RerouteCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            OnCellEnterReroute?.Invoke(sender, cellIndex);
        }

        public void RerouteCellExit(TerrainGridSystem sender, int cellIndex)
        {
            OnCellExitReroute?.Invoke(sender, cellIndex);
        }
    }
}