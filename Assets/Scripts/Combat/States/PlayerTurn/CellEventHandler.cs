using RainesGames.Grid;
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

        bool NoValidUnitSelected()
        {
            return UnitSelectionManager.ActiveUnit == null || UnitSelectionManager.ActiveUnit.IsEnemy();
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(NoValidUnitSelected())
                return;

            _state.Manager.CellEventRouter.RerouteCellClick(UnitSelectionManager.ActiveUnit, cellIndex, sender, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            if(NoValidUnitSelected())
                return;

            _state.Manager.CellEventRouter.RerouteCellEnter(UnitSelectionManager.ActiveUnit, cellIndex, sender);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            if(NoValidUnitSelected())
                return;

            _state.Manager.CellEventRouter.RerouteCellExit(UnitSelectionManager.ActiveUnit, cellIndex, sender);
        }
    }
}