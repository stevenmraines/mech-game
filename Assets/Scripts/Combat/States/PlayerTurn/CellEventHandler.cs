using RainesGames.Common;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class CellEventHandler : ICellEvents
    {
        private PlayerTurnState _state;

        public CellEventHandler(PlayerTurnState playerTurnState)
        {
            _state = playerTurnState;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null || UnitSelectionManager.ActiveUnit.IsEnemy())
                return;

            _state.Manager.CellEventRouter.RerouteCellClick(sender, cellIndex, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            _state.Manager.CellEventRouter.RerouteCellEnter(sender, cellIndex);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            _state.Manager.CellEventRouter.RerouteCellExit(sender, cellIndex);
        }
    }
}