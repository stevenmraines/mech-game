using RainesGames.Common.States;
using RainesGames.Common.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        public void DeregisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute -= OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute -= OnUnitEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute -= OnUnitExit;
        }

        UnitStateManager GetStateManager()
        {
            return UnitSelectionManager.ActiveUnit.StateManager;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitEnter(UnitController unit)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitEnter(unit);
        }

        public void OnUnitExit(UnitController unit)
        {
            GetStateManager().CurrentState.UnitEventHandler?.OnUnitExit(unit);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute += OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute += OnUnitEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute += OnUnitExit;
        }
    }
}