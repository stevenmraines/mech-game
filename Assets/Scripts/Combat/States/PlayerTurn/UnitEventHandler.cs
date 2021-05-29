using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(PlayerTurnState playerTurnState) : base(playerTurnState) {}

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit != UnitSelectionManager.ActiveUnit)
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public override void OnUnitMouseEnter(UnitController unit)
        {
            GridManager.DisableCellHighlight();
        }

        public override void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();
        }
    }
}