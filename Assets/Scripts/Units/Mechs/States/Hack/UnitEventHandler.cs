using RainesGames.Units.Selection;
using RainesGames.Units.Usables.Abilities.Hack;

namespace RainesGames.Units.Mechs.States.Hack
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<HackAbility>().Execute(unit);
        }

        public void OnUnitEnter(IUnit unit) { }

        public void OnUnitExit(IUnit unit) { }
    }
}