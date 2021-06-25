using RainesGames.Common.States;
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

        IUnitEvents GetUnitEventHandler()
        {
            IUnitState currentState = UnitSelectionManager.ActiveUnit.CurrentState;

            if(currentState is IUnitTargetState)
                return ((IUnitTargetState)currentState).UnitEventHandler;

            return null;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            GetUnitEventHandler()?.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitEnter(UnitController unit)
        {
            GetUnitEventHandler()?.OnUnitEnter(unit);
        }

        public void OnUnitExit(UnitController unit)
        {
            GetUnitEventHandler()?.OnUnitExit(unit);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute += OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute += OnUnitEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute += OnUnitExit;
        }
    }
}