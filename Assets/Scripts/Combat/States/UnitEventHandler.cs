using RainesGames.Common.States;
using RainesGames.Units;

namespace RainesGames.Combat.States
{
    public abstract class UnitEventHandler : StateEventHandler<CombatState>, IUnitEvents
    {
        public UnitEventHandler(CombatState combatState) : base(combatState) { }

        public abstract void OnUnitClick(UnitController unit, int buttonIndex);
        public abstract void OnUnitMouseEnter(UnitController unit);
        public abstract void OnUnitMouseExit(UnitController unit);
    }
}