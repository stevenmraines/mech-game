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

        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            if(unit.IsPlayer())
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public void OnUnitEnter(IUnit unit) { }

        public void OnUnitExit(IUnit unit) { }
    }
}