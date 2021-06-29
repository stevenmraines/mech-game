using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Selection;

namespace RainesGames.Units.Mechs.States.FactoryReset
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<FactoryResetAbility>().Execute(unit);
        }

        public void OnUnitEnter(AbsUnit unit) { }

        public void OnUnitExit(AbsUnit unit) { }
    }
}