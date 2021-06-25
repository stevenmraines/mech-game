using RainesGames.Common.States;
using RainesGames.Grid;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Units.States
{
    // TODO This class may not be needed, along with UnitEventRouter
    public class CellEventRouter : IStateEventRouter, ICellEvents
    {
        public void DeregisterEventHandlers()
        {
            Combat.States.CellEventRouter.OnCellClickReroute -= OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute -= OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute -= OnCellExit;
        }

        ICellEvents GetCellEventHandler()
        {
            IUnitState currentState = UnitSelectionManager.ActiveUnit.CurrentState;
            
            if(currentState is ICellTargetState)
                return ((ICellTargetState)currentState).CellEventHandler;

            return null;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            GetCellEventHandler()?.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            GetCellEventHandler()?.OnCellEnter(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            GetCellEventHandler()?.OnCellExit(sender, cellIndex);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.CellEventRouter.OnCellClickReroute += OnCellClick;
            Combat.States.CellEventRouter.OnCellEnterReroute += OnCellEnter;
            Combat.States.CellEventRouter.OnCellExitReroute += OnCellExit;
        }
    }
}