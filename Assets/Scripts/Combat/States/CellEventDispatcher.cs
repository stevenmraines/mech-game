using RainesGames.Common.States;
using RainesGames.Selection;

namespace RainesGames.Combat.States
{
    public class CellEventDispatcher : IStateEventDispatcher
    {
        private StateManager _manager;

        public CellEventDispatcher(StateManager manager)
        {
            _manager = manager;
        }

        public void DeregisterEventHandlers()
        {
            SelectionManager.OnCellClick -= OnCellClick;
        }

        void OnCellClick(int cellIndex, int buttonIndex)
        {
            ((State)_manager.CurrentState).OnCellClick(cellIndex, buttonIndex);
        }

        public void RegisterEventHandlers()
        {
            SelectionManager.OnCellClick += OnCellClick;
        }
    }
}