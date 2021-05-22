using RainesGames.Common.States;
using RainesGames.Selection;

namespace RainesGames.Combat.States
{
    public class CellEventDispatcher : StateEventDispatcher<CombatState>, ICellEvents
    {
        public CellEventDispatcher(CombatStateManager manager) : base(manager) {}

        public override void DeregisterEventHandlers()
        {
            SelectionManager.OnCellClick -= OnCellClick;
        }

        public void OnCellClick(int cellIndex, int buttonIndex)
        {
            _manager.CurrentState.CellEventHandler.OnCellClick(cellIndex, buttonIndex);
        }

        public override void RegisterEventHandlers()
        {
            SelectionManager.OnCellClick += OnCellClick;
        }
    }
}