using RainesGames.Common;
using RainesGames.Common.States;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States
{
    public class UnitEventRouter : IStateEventRouter, IUnitEvents
    {
        private CombatStateManager _manager;

        public delegate void UnitClickDelegate(UnitController unit, int buttonIndex);
        public static event UnitClickDelegate OnUnitClickReroute;

        public delegate void UnitMouseEventDelegate(UnitController unit);
        public static event UnitMouseEventDelegate OnUnitMouseEnterReroute;
        public static event UnitMouseEventDelegate OnUnitMouseExitReroute;

        public UnitEventRouter(CombatStateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            UnitSelectionManager.OnUnitClick -= OnUnitClick;
            UnitSelectionManager.OnUnitMouseEnter -= OnUnitMouseEnter;
            UnitSelectionManager.OnUnitMouseExit -= OnUnitMouseExit;
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
            UnitSelectionManager.OnUnitClick += OnUnitClick;
            UnitSelectionManager.OnUnitMouseEnter += OnUnitMouseEnter;
            UnitSelectionManager.OnUnitMouseExit += OnUnitMouseExit;
        }

        public void RerouteUnitClick(UnitController unit, int buttonIndex)
        {
            OnUnitClickReroute?.Invoke(unit, buttonIndex);
        }
        
        public void RerouteUnitMouseEnter(UnitController unit)
        {
            OnUnitMouseEnterReroute?.Invoke(unit);
        }
        
        public void RerouteUnitMouseExit(UnitController unit)
        {
            OnUnitMouseExitReroute?.Invoke(unit);
        }
    }
}