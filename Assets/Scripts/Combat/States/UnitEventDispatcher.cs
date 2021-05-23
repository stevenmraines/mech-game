using RainesGames.Common.States;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States
{
    public class UnitEventDispatcher : StateEventDispatcher<CombatState>, IUnitEvents
    {
        public UnitEventDispatcher(CombatStateManager manager) : base(manager) {}

        public override void DeregisterEventHandlers()
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

        public override void RegisterEventHandlers()
        {
            UnitSelectionManager.OnUnitClick += OnUnitClick;
            UnitSelectionManager.OnUnitMouseEnter += OnUnitMouseEnter;
            UnitSelectionManager.OnUnitMouseExit += OnUnitMouseExit;
        }
    }
}