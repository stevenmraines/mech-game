using RainesGames.Units.Abilities.Hack;
using UnityEngine;

namespace RainesGames.Units.States.Hack
{
    public class HackState : MonoBehaviour, IUnitState, IUnitTargetState
    {
        private IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;

        void Awake()
        {
            _unitEventHandler = new UnitEventHandler();
        }

        public bool CanEnterState(UnitController unit)
        {
            HackAbility ability = unit.GetAbility<HackAbility>();
            return ability != null && ability.AbilityIsAffordable() && ability.IsPowered();
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}