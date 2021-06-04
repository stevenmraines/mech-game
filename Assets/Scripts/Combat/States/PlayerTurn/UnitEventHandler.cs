using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class UnitEventHandler : IUnitEvents
    {
        private PlayerTurnState _state;

        public UnitEventHandler(PlayerTurnState playerTurnState)
        {
            _state = playerTurnState;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            UnitSelectionManager.SetActiveUnit(unit);
        }

        public void OnUnitMouseEnter(UnitController unit)
        {
            GridManager.DisableCellHighlight();
        }

        public void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();
        }
    }
}