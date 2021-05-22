using RainesGames.Units;

namespace RainesGames.Combat.States.BattleStart
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(BattleStartState battleStartState) : base(battleStartState) {}

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            throw new System.NotImplementedException();
        }

        public override void OnUnitMouseEnter(UnitController unit)
        {
            throw new System.NotImplementedException();
        }

        public override void OnUnitMouseExit(UnitController unit)
        {
            throw new System.NotImplementedException();
        }
    }
}