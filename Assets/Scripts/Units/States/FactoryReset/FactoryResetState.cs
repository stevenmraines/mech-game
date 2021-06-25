using RainesGames.Units.Abilities.FactoryReset;
using UnityEngine;

namespace RainesGames.Units.States.FactoryReset
{
    public class FactoryResetState : MonoBehaviour, IUnitState, IUnitTargetState
    {
        private IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;

        void Awake()
        {
            _unitEventHandler = new UnitEventHandler();
        }

        public bool CanEnterState(UnitController unit)
        {
            FactoryResetAbility ability = unit.GetAbility<FactoryResetAbility>();
            return ability != null && ability.AbilityIsAffordable() && ability.IsPowered();
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}