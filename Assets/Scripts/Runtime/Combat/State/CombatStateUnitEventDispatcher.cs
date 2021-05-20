public class CombatStateUnitEventDispatcher : IStateEventDispatcher
{
    private CombatStateManager _manager;

    public CombatStateUnitEventDispatcher(CombatStateManager manager)
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
        ((CombatState)_manager.CurrentState).OnUnitClick(unit, buttonIndex);
    }

    void OnUnitMouseEnter(UnitController unit)
    {
        ((CombatState)_manager.CurrentState).OnUnitMouseEnter(unit);
    }

    void OnUnitMouseExit(UnitController unit)
    {
        ((CombatState)_manager.CurrentState).OnUnitMouseExit(unit);
    }

    public void RegisterEventHandlers()
    {
        SelectionManager.OnUnitClick += OnUnitClick;
        SelectionManager.OnUnitMouseEnter += OnUnitMouseEnter;
        SelectionManager.OnUnitMouseExit += OnUnitMouseExit;
    }
}
