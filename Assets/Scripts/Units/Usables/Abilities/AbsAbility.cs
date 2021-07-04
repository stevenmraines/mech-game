using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    [RequireComponent(typeof(AbsUnit))]
    public abstract class AbsAbility : MonoBehaviour, IAbility
    {
        /*
         * Some tight coupling between abilities and units should be okay,
         * since every ability will belong to a particular unit.
         */
        protected AbsUnit _parentUnit;

        protected virtual void Awake()
        {
            _parentUnit = GetComponent<AbsUnit>();
        }

        public abstract bool CanBeUsed();

        protected virtual void DecrementAbilityPoints()
        {
            _parentUnit.DecrementAbilityPoints(GetAbilityCost());
        }
        
        public virtual int GetAbilityCost()
        {
            return _parentUnit.FirstAbilitySpent() ? GetSecondAbilityCost() : GetFirstAbilityCost();
        }

        public abstract int GetFirstAbilityCost();

        public abstract int GetSecondAbilityCost();

        public abstract AudioClip GetSoundEffect();

        public abstract UnitState GetState();

        public virtual bool IsAffordable()
        {
            return _parentUnit.GetAbilityPoints() >= GetAbilityCost();
        }

        public abstract bool ShowInTray();
    }
}