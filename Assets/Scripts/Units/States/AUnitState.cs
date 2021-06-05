using RainesGames.Common;
using RainesGames.Common.States;

namespace RainesGames.Units.States
{
    public abstract class AUnitState : IState
    {
        protected UnitStateManager _manager;

        protected ICellEvents _cellEventHandler;
        public ICellEvents CellEventHandler => _cellEventHandler;

        protected IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;

        protected bool _entered = false;
        public bool Entered => _entered;

        public AUnitState(UnitStateManager manager)
        {
            _manager = manager;
        }

        public abstract bool CanEnterState();

        public virtual void EnterState()
        {
            _entered = true;
        }

        public virtual void ExitState()
        {
            _entered = false;
        }

        public abstract void UpdateState();
    }
}