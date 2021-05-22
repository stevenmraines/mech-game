using RainesGames.Common.States;

namespace RainesGames.Combat.States
{
    public abstract class CellEventHandler : StateEventHandler<CombatState>, ICellEvents
    {
        public CellEventHandler(CombatState combatState) : base(combatState) {}

        public abstract void OnCellClick(int cellIndex, int buttonIndex);
    }
}