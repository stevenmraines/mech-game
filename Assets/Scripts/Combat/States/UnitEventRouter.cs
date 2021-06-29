using RainesGames.Common.States;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        private CombatStateManager _manager;

        public delegate void UnitClickDelegate(AbsUnit unit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClickReroute;

        public delegate void UnitMouseTransitEventsDelegate(AbsUnit unit);
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

        public void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitClick(unit, buttonIndex);
        }

        public void OnUnitEnter(AbsUnit unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitEnter(unit);
        }

        public void OnUnitExit(AbsUnit unit)
        {
            _manager.CurrentState.UnitEventHandler.OnUnitExit(unit);
        }

        public void RegisterEventHandlers()
        {
            UnitSelectionManager.OnUnitClick += OnUnitClick;
            UnitSelectionManager.OnUnitEnter += OnUnitEnter;
            UnitSelectionManager.OnUnitExit += OnUnitExit;
        }

        public void RerouteUnitClick(AbsUnit unit, int buttonIndex)
        {
            OnUnitClickReroute?.Invoke(unit, buttonIndex);
        }
        
        public void RerouteUnitMouseEnter(AbsUnit unit)
        {
            OnUnitEnterReroute?.Invoke(unit);
        }
        
        public void RerouteUnitMouseExit(AbsUnit unit)
        {
            OnUnitExitReroute?.Invoke(unit);
        }
    }
}