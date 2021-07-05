using RainesGames.Common.States;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        private CombatStateManager _manager;

        public delegate void UnitClickDelegate(IUnit unit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClickReroute;

        public delegate void UnitMouseTransitEventsDelegate(IUnit unit);
        public static event UnitMouseTransitEventsDelegate OnUnitEnterReroute;
        public static event UnitMouseTransitEventsDelegate OnUnitExitReroute;

        public UnitEventRouter(CombatStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            UnitSelectionManager.OnUnitClick -= OnUnitClick;
            UnitSelectionManager.OnUnitEnter -= OnUnitEnter;
            UnitSelectionManager.OnUnitExit -= OnUnitExit;
        }

        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitEnter(IUnit unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitEnter(unit);
        }

        public void OnUnitExit(IUnit unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitExit(unit);
        }

        public void RegisterEventHandlers()
        {
            UnitSelectionManager.OnUnitClick += OnUnitClick;
            UnitSelectionManager.OnUnitEnter += OnUnitEnter;
            UnitSelectionManager.OnUnitExit += OnUnitExit;
        }

        public void RerouteUnitClick(IUnit unit, int buttonIndex)
        {
            OnUnitClickReroute?.Invoke(unit, buttonIndex);
        }
        
        public void RerouteUnitMouseEnter(IUnit unit)
        {
            OnUnitEnterReroute?.Invoke(unit);
        }
        
        public void RerouteUnitMouseExit(IUnit unit)
        {
            OnUnitExitReroute?.Invoke(unit);
        }
    }
}