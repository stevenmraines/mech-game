public class CombatStateCellEventDispatcher : IStateEventDispatcher
{
    private CombatStateManager _manager;

    public CombatStateCellEventDispatcher(CombatStateManager manager)
    {
        _manager = manager;
    }

    public void DeregisterEventHandlers()
    {
        SelectionManager.OnCellClick -= OnCellClick;
    }

    void OnCellClick(int cellIndex, int buttonIndex)
    {
        ((CombatState)_manager.CurrentState).OnCellClick(cellIndex, buttonIndex);
    }

    public void RegisterEventHandlers()
    {
        SelectionManager.OnCellClick += OnCellClick;
    }
}
