using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class UnitEventHandler : IUnitEvents
    {
        private EnemyTurnState _state;

        public UnitEventHandler(EnemyTurnState enemyTurnState)
        {
            _state = enemyTurnState;
        }

        bool CanSetActiveUnit()
        {
            IUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return true;

            // TODO can't I just check if the active unit is in the noAP/move state?
            bool playerIsTargetingUnits = activeUnit.IsEnemy() && activeUnit.GetActiveUsable() is IUnitEvents;

            if(!playerIsTargetingUnits)
                return true;

            return false;
        }

        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            if(CanSetActiveUnit())
            {
                UnitSelectionManager.SetActiveUnit(unit);
                return;
            }

            _state.Manager.UnitEventRouter.RerouteUnitClick(unit, buttonIndex);
        }

        public void OnUnitEnter(IUnit unit)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            _state.Manager.UnitEventRouter.RerouteUnitMouseEnter(unit);
        }

        public void OnUnitExit(IUnit unit)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            _state.Manager.UnitEventRouter.RerouteUnitMouseExit(unit);
        }
    }
}