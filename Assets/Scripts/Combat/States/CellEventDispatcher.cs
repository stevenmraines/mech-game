using RainesGames.Common;
using RainesGames.Common.States;
using RainesGames.Grid;
using RainesGames.Grid.Selection;
using TGS;

namespace RainesGames.Combat.States
{
    public class CellEventDispatcher : IStateEventDispatcher, ICellEvents
    {
        private CombatStateManager _manager;

        public CellEventDispatcher(CombatStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            GridSelectionManager.OnCellClick -= OnCellClick;
            GridManager.TerrainGridSystem.OnCellEnter -= OnCellEnter;
            GridManager.TerrainGridSystem.OnCellExit -= OnCellExit;
        }

        public void OnCellClick(int cellIndex, int buttonIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellClick(cellIndex, buttonIndex);
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
    }
}