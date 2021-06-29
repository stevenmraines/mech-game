using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Selection;

namespace RainesGames.Units.Mechs.States.Underclock
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<UnderclockAbility>().Execute(unit);
        }

        public void OnUnitEnter(AbsUnit unit) { }

        public void OnUnitExit(AbsUnit unit) { }
    }
}