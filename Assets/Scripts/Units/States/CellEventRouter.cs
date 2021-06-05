using RainesGames.Common;
using RainesGames.Common.States;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Units.States
{
    public class CellEventRouter : IStateEventRouter, ICellEvents
    {
        public void DeregisterEventHandlers()
        {
            Combat.States.CellEventRouter.OnCellClickReroute -= OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute -= OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute -= OnCellExit;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            UnitStateManager unitStateManager = UnitSelectionManager.ActiveUnit.StateManager;
            unitStateManager.CurrentState.CellEventHandler.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            UnitStateManager unitStateManager = UnitSelectionManager.ActiveUnit.StateManager;
            unitStateManager.CurrentState.CellEventHandler.OnCellEnter(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            UnitStateManager unitStateManager = UnitSelectionManager.ActiveUnit.StateManager;
            unitStateManager.CurrentState.CellEventHandler.OnCellExit(sender, cellIndex);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.CellEventRouter.OnCellClickReroute += OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute += OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute += OnCellExit;
        }
    }
}