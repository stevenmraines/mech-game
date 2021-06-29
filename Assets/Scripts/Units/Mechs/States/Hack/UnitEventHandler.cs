using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Selection;

namespace RainesGames.Units.Mechs.States.Hack
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<HackAbility>().Execute(unit);
        }

        public void OnUnitEnter(AbsUnit unit) { }

        public void OnUnitExit(AbsUnit unit) { }
    }
}