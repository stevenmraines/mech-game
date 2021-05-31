using RainesGames.Common.States;
using TGS;

namespace RainesGames.Combat.States
{
    public abstract class CellEventHandler : StateEventHandler<CombatState>, ICellEvents
    {
        public CellEventHandler(CombatState combatState) : base(combatState) {}

        public abstract void OnCellClick(int cellIndex, int buttonIndex);
        public abstract void OnCellEnter(TerrainGridSystem sender, int cellIndex);
        public abstract void OnCellExit(TerrainGridSystem sender, int cellIndex);
    }
}