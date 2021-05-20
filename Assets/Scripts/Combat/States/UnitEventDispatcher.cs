using RainesGames.Common.States;
using RainesGames.Selection;
using RainesGames.Units;

namespace RainesGames.Combat.States
{
    public class UnitEventDispatcher : IStateEventDispatcher
    {
        private StateManager _manager;

        public UnitEventDispatcher(StateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            SelectionManager.OnUnitClick -= OnUnitClick;
            SelectionManager.OnUnitMouseEnter -= OnUnitMouseEnter;
            SelectionManager.OnUnitMouseExit -= OnUnitMouseExit;
        }

        void OnUnitClick(UnitController unit, int buttonIndex)
        {
            ((State)_manager.CurrentState).OnUnitClick(unit, buttonIndex);
        }

        void OnUnitMouseEnter(UnitController unit)
        {
            ((State)_manager.CurrentState).OnUnitMouseEnter(unit);
        }

        void OnUnitMouseExit(UnitController unit)
        {
            ((State)_manager.CurrentState).OnUnitMouseExit(unit);
        }

        public void RegisterEventHandlers()
        {
            SelectionManager.OnUnitClick += OnUnitClick;
            SelectionManager.OnUnitMouseEnter += OnUnitMouseEnter;
            SelectionManager.OnUnitMouseExit += OnUnitMouseExit;
        }
    }
}