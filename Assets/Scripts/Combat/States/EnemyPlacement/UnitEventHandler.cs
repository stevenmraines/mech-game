using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class UnitEventHandler : IUnitEvents
    {
        private EnemyPlacementState _state;

        public UnitEventHandler(EnemyPlacementState enemyPlacementState)
        {
            _state = enemyPlacementState;
        }

        public void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            if(unit.IsEnemy())
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public void OnUnitEnter(AbsUnit unit) { }

        public void OnUnitExit(AbsUnit unit) { }
    }
}