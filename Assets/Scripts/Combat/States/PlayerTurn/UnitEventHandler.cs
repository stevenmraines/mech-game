using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;
using RainesGames.Units.States;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class UnitEventHandler : IUnitEvents
    {
        private PlayerTurnState _state;

        public UnitEventHandler(PlayerTurnState playerTurnState)
        {
            _state = playerTurnState;
        }

        bool CanSetActiveUnit()
        {
            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return true;

            AUnitState currentState = UnitSelectionManager.ActiveUnit.StateManager.CurrentState;
            bool activeUnitIsTargetingUnits = activeUnit.IsPlayer() && currentState.IsUnitTargetingState();

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