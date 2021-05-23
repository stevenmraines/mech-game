using RainesGames.Grid;
using RainesGames.Units;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(EnemyPlacementState enemyPlacementState) : base(enemyPlacementState) {}

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit.IsEnemy())
                unit.StateManager.TransitionToState(unit.StateManager.Active);
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