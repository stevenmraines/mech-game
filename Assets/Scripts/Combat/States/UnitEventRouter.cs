using RainesGames.Common.States;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        private CombatStateManager _manager;

        public delegate void UnitClickDelegate(IUnit activeUnit, IUnit targetUnit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClickReroute;

        public delegate void UnitTransitEventsDelegate(IUnit activeUnit, IUnit targetUnit);
        public static event UnitTransitEventsDelegate OnUnitEnterReroute;
        public static event UnitTransitEventsDelegate OnUnitExitReroute;

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

        public void RerouteUnitClick(IUnit activeUnit, IUnit targetUnit, int buttonIndex)
        {
            OnUnitClickReroute?.Invoke(activeUnit, targetUnit, buttonIndex);
        }
        
        public void RerouteUnitMouseEnter(IUnit activeUnit, IUnit targetUnit)
        {
            OnUnitEnterReroute?.Invoke(activeUnit, targetUnit);
        }
        
        public void RerouteUnitMouseExit(IUnit activeUnit, IUnit targetUnit)
        {
            OnUnitExitReroute?.Invoke(activeUnit, targetUnit);
        }
    }
}