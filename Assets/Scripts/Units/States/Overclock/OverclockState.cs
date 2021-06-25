using RainesGames.Units.Abilities.Overclock;
using UnityEngine;

namespace RainesGames.Units.States.Overclock
{
    public class OverclockState : MonoBehaviour, IUnitState, IUnitTargetState
    {
        private IUnitEvents _unitEventHandler;
        public IUnitEvents UnitEventHandler => _unitEventHandler;
        
        void Awake()
        {
             _unitEventHandler = new UnitEventHandler();
        }

        public bool CanEnterState(UnitController unit)
        {
            OverclockAbility ability = unit.GetAbility<OverclockAbility>();
            return ability != null && ability.AbilityIsAffordable() && ability.IsPowered();
        }

        public void EnterState(UnitController unit) { }

        public void ExitState(UnitController unit) { }
    }
}