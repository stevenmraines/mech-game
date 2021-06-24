using RainesGames.Common.Units;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class UnitEventHandler : IUnitEvents
    {
        private PlayerPlacementState _state;

        public UnitEventHandler(PlayerPlacementState playerPlacementState)
        {
            _state = playerPlacementState;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit.IsPlayer())
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public void OnUnitEnter(UnitController unit)
        {
            // TODO Figure out how to use lambda expressions for these one line event handlers
            GridWrapper.DisableCellHighlight();
        }

        public void OnUnitExit(UnitController unit)
        {
            GridWrapper.EnableCellHighlight();
        }
    }
}