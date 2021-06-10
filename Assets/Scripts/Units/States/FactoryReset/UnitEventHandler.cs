using RainesGames.Common;
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

        public void OnUnitMouseEnter(UnitController unit) { }

        public void OnUnitMouseExit(UnitController unit) { }
    }
}