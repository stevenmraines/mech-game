using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(AbsUnit))]
    public abstract class AbsAbility : MonoBehaviour, IAbility
    {
        /*
         * Some tight coupling between abilities and units should be okay,
         * since every ability will belong to a particular unit.
         */
        protected AbsUnit _controller;

        protected int _firstAbilityCost;
        public int FirstAbilityCost => _firstAbilityCost;

        protected int _secondAbilityCost;
        public int SecondAbilityCost => _secondAbilityCost;

        protected bool _showInTray = true;
        public bool ShowInTray => _showInTray;

        protected AudioClip _soundEffect;

        protected UnitState _state;
        public UnitState State => _state;

        protected virtual void Awake()
        {
            _controller = GetComponent<AbsUnit>();
        }

        protected virtual void DecrementAbilityPoints()
        {
            _controller.DecrementAbilityPoints(GetAbilityCost());
        }

        public virtual int GetAbilityCost()
        {
            return _controller.GetFirstAbilitySpent() ? _secondAbilityCost : _firstAbilityCost;
        }

        public virtual bool IsAffordable()
        {
            return _controller.GetAbilityPoints() >= GetAbilityCost();
        }
    }
}