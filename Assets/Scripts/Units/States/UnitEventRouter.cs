using RainesGames.Common;
using RainesGames.Common.States;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        public void DeregisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute -= OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute -= OnUnitMouseEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute -= OnUnitMouseExit;
        }

        UnitStateManager GetStateManager()
        {
            return UnitSelectionManager.ActiveUnit.StateManager;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitMouseEnter(UnitController unit)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitMouseEnter(unit);
        }

        public void OnUnitMouseExit(UnitController unit)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitMouseExit(unit);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute += OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute += OnUnitMouseEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute += OnUnitMouseExit;
        }
    }
}