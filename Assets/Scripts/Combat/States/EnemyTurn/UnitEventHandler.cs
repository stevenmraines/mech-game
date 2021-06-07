using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;
using RainesGames.Units.States;

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
            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return true;

            AUnitState currentState = UnitSelectionManager.ActiveUnit.StateManager.CurrentState;
            bool activeUnitIsTargetingUnits = activeUnit.IsEnemy() && currentState.IsUnitTargetingState();

            if(!activeUnitIsTargetingUnits)
                return true;

            return false;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(CanSetActiveUnit())
            {
                UnitSelectionManager.SetActiveUnit(unit);
                return;
            }

            _state.Manager.UnitEventRouter.RerouteUnitClick(unit, buttonIndex);
        }

        public void OnUnitMouseEnter(UnitController unit)
        {
            GridManager.DisableCellHighlight();

            if(UnitSelectionManager.ActiveUnit == null)
                return;

            _state.Manager.UnitEventRouter.RerouteUnitMouseEnter(unit);
        }

        public void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();

            if(UnitSelectionManager.ActiveUnit == null)
                return;

            _state.Manager.UnitEventRouter.RerouteUnitMouseExit(unit);
        }
    }
}