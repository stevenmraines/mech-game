using RainesGames.Units.Abilities.Underclock;
using UnityEngine;

namespace RainesGames.Units.States.Underclock
{
    public class UnderclockState : MonoBehaviour, IUnitState, IUnitTargetState
    {
        private IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;
        
        void Awake()
        {
            _unitEventHandler = new UnitEventHandler();
        }

        public bool CanEnterState(UnitController unit)
        {
            UnderclockAbility ability = unit.GetAbility<UnderclockAbility>();
            return ability != null && ability.AbilityIsAffordable() && ability.IsPowered();
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}