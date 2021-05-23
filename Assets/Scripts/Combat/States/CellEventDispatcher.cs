using RainesGames.Common.States;
using RainesGames.Grid.Selection;

namespace RainesGames.Combat.States
{
    public class CellEventDispatcher : StateEventDispatcher<CombatState>, ICellEvents
    {
        public CellEventDispatcher(CombatStateManager manager) : base(manager) {}

        public override void DeregisterEventHandlers()
        {
            GridSelectionManager.OnCellClick -= OnCellClick;
        }

        public void OnCellClick(int cellIndex, int buttonIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellClick(cellIndex, buttonIndex);
        }

        public override void RegisterEventHandlers()
        {
            GridSelectionManager.OnCellClick += OnCellClick;
        }
    }
}