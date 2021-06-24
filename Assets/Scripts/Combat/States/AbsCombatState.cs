using RainesGames.Common.Grid;
using RainesGames.Common.States;
using RainesGames.Common.Units;
using UnityEngine;

namespace RainesGames.Combat.States
{
    public abstract class AbsCombatState : MonoBehaviour, IState, IStateUpdateable
    {
        protected CombatStateManager _manager;
        public CombatStateManager Manager => _manager;

        protected ICellEvents _cellEventHandler;
        public ICellEvents CellEventHandler => _cellEventHandler;

        protected IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;

        protected bool _entered = false;
        public bool Entered => _entered;

        protected string _stateName;
        public string StateName => _stateName;

        protected virtual void Awake()
        {
            _manager = GetComponent<CombatStateManager>();
        }

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