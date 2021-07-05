using RainesGames.Units.Selection;
using RainesGames.Units.Usables.Abilities.FactoryReset;

namespace RainesGames.Units.Mechs.States.FactoryReset
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<FactoryResetAbility>().Use(unit);
        }

        public void OnUnitEnter(IUnit unit) { }

        public void OnUnitExit(IUnit unit) { }
    }
}