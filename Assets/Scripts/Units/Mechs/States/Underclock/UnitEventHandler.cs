using RainesGames.Units.Selection;
using RainesGames.Units.Usables.Abilities.Underclock;

namespace RainesGames.Units.Mechs.States.Underclock
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<UnderclockAbility>().Execute(unit);
        }

        public void OnUnitEnter(IUnit unit) { }

        public void OnUnitExit(IUnit unit) { }
    }
}