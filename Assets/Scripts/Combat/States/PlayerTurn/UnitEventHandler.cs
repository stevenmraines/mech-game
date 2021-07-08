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

        bool CanSetActiveUnit()
        {
            IUnit activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null)
                return true;

            bool playerIsTargetingUnits = activeUnit.IsPlayer() && activeUnit.GetActiveUsable() is IUnitEvents;

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