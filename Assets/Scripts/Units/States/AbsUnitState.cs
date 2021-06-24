using RainesGames.Common.Grid;
using RainesGames.Common.States;
using RainesGames.Common.Units;

namespace RainesGames.Units.States
{
    public abstract class AbsUnitState : IState
    {
        protected UnitStateManager _manager;

        protected ICellEvents _cellEventHandler;
        public ICellEvents CellEventHandler => _cellEventHandler;

        protected IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;

        public AbsUnitState(UnitStateManager manager)
        {
            _manager = manager;
        }

        public abstract bool CanEnterState();

        public abstract void EnterState();

        public abstract void ExitState();

        public bool IsCellTargetingState()
        {
            return _cellEventHandler != null;
        }

        public bool IsUnitTargetingState()
        {
            return _unitEventHandler != null;
        }
    }
}