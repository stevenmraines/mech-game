using RainesGames.Common.States;

namespace RainesGames.Combat.States
{
    public abstract class CombatState : State
    {
        protected CombatStateManager _manager;

        public CellEventHandler CellEventHandler;
        public UnitEventHandler UnitEventHandler;

        public virtual void Awake()
        {
            _manager = GetComponent<CombatStateManager>();
        }
    }
}