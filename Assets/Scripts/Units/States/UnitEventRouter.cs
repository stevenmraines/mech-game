using RainesGames.Common;
using RainesGames.Common.States;

namespace RainesGames.Units.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        private UnitStateManager _manager;

        public UnitEventRouter(UnitStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute -= OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute -= OnUnitMouseEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute -= OnUnitMouseExit;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitMouseEnter(UnitController unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitMouseEnter(unit);
        }

        public void OnUnitMouseExit(UnitController unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitMouseExit(unit);
        }

        public void RegisterEventHandlers()
        {
            Combat.States.UnitEventRouter.OnUnitClickReroute += OnUnitClick;
            Combat.States.UnitEventRouter.OnUnitMouseEnterReroute += OnUnitMouseEnter;
            Combat.States.UnitEventRouter.OnUnitMouseExitReroute += OnUnitMouseExit;
        }
    }
}