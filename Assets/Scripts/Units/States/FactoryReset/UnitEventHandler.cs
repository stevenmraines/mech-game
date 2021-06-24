using RainesGames.Common.Units;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States.FactoryReset
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<FactoryResetAbility>().Execute(unit);
        }

        public void OnUnitEnter(UnitController unit) { }

        public void OnUnitExit(UnitController unit) { }
    }
}