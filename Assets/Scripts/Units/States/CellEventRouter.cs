using RainesGames.Common;
using RainesGames.Common.States;
using TGS;

namespace RainesGames.Units.States
{
    public class CellEventRouter : IStateEventRouter, ICellEvents
    {
        private UnitStateManager _manager;

        public CellEventRouter(UnitStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            Combat.States.CellEventRouter.OnCellClickReroute -= OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute -= OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute -= OnCellExit;
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
            Combat.States.CellEventRouter.OnCellClickReroute += OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute += OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute += OnCellExit;
        }
    }
}