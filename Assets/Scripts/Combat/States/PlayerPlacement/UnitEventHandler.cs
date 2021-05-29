using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(PlayerPlacementState playerPlacementState) : base(playerPlacementState) {}

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit.IsPlayer())
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public override void OnUnitMouseEnter(UnitController unit)
        {
            // TODO Figure out how to use lambda expressions for these one line event handlers
            GridManager.DisableCellHighlight();
        }

        public override void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();
        }
    }
}