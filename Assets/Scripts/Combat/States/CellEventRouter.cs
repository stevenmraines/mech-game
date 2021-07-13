using RainesGames.Common.States;
using RainesGames.Grid;
using RainesGames.Grid.Selection;
using RainesGames.Units;
using TGS;

namespace RainesGames.Combat.States
{
    public class CellEventRouter : IStateEventRouter, ICellEvents
    {
        private CombatStateManager _manager;
        
        public delegate void CellClickDelegate(IUnit activeUnit, int cellIndex, TerrainGridSystem sender, int buttonIndex);
        public static event CellClickDelegate OnCellClickReroute;

        public delegate void CellTransitDelegate(IUnit activeUnit, int cellIndex, TerrainGridSystem sender);
        public static event CellTransitDelegate OnCellEnterReroute;
        public static event CellTransitDelegate OnCellExitReroute;

        public CellEventRouter(CombatStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            CellSelectionManager.OnCellClick -= OnCellClick;
            GridWrapper.TerrainGridSystem.OnCellEnter -= OnCellEnter;
            GridWrapper.TerrainGridSystem.OnCellExit -= OnCellExit;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            _manager.CurrentState.CellEventHandler?.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            _manager.CurrentState.CellEventHandler?.OnCellEnter(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            _manager.CurrentState.CellEventHandler?.OnCellExit(sender, cellIndex);
        }

        public void RegisterEventHandlers()
        {
            CellSelectionManager.OnCellClick += OnCellClick;
            GridWrapper.TerrainGridSystem.OnCellEnter += OnCellEnter;
            GridWrapper.TerrainGridSystem.OnCellExit += OnCellExit;
        }

        public void RerouteCellClick(IUnit activeUnit, int cellIndex, TerrainGridSystem sender, int buttonIndex)
        {
            OnCellClickReroute?.Invoke(activeUnit, cellIndex, sender, buttonIndex);
        }

        public void RerouteCellEnter(IUnit activeUnit, int cellIndex, TerrainGridSystem sender)
        {
            OnCellEnterReroute?.Invoke(activeUnit, cellIndex, sender);
        }

        public void RerouteCellExit(IUnit activeUnit, int cellIndex, TerrainGridSystem sender)
        {
            OnCellExitReroute?.Invoke(activeUnit, cellIndex, sender);
        }
    }
}