using RainesGames.Common.Units;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States.Hack
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<HackAbility>().Execute(unit);
        }

        public void OnUnitEnter(UnitController unit) { }

        public void OnUnitExit(UnitController unit) { }
    }
}