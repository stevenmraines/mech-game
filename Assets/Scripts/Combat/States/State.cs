using RainesGames.Units;

namespace RainesGames.Combat.States
{
    public abstract class State : Common.States.State, IState
    {
        protected StateManager _manager;

        public virtual void Awake()
        {
            _manager = GetComponent<StateManager>();
        }

        public abstract void OnCellClick(int cellIndex, int buttonIndex);
        public abstract void OnUnitClick(UnitController unit, int buttonIndex);
        public abstract void OnUnitMouseEnter(UnitController unit);
        public abstract void OnUnitMouseExit(UnitController unit);
    }
}