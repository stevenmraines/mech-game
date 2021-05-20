using RainesGames.Units;

namespace RainesGames.Combat.States
{
    public class PlayerLostState : State
    {
        public override void Awake()
        {
            base.Awake();
            StateName = "Player Lost";
        }

        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {

        }

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {

        }

        public override void OnUnitMouseEnter(UnitController unit)
        {

        }

        public override void OnUnitMouseExit(UnitController unit)
        {

        }

        public override void UpdateState()
        {

        }
    }
}