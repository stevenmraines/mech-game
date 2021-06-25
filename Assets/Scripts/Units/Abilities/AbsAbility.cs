using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(UnitController))]
    public abstract class AbsAbility : MonoBehaviour, IAbility
    {
        protected UnitController _controller;
        public UnitController Controller => _controller;

        protected int _firstAbilityCost;
        public int FirstAbilityCost => _firstAbilityCost;

        protected int _secondAbilityCost;
        public int SecondAbilityCost => _secondAbilityCost;

        protected IUnitState _state;
        public IUnitState State => _state;

        protected bool _showInTray = true;
        public bool ShowInTray => _showInTray;

        public virtual bool AbilityIsAffordable()
        {
            return _controller.AbilityPoints >= GetAbilityPointCost();
        }

        protected virtual void DecrementAbilityPoints()
        {
            _controller.AbilityPointsManager.Decrement(_controller, GetAbilityPointCost());
        }

        public virtual int GetAbilityPointCost()
        {
            return _controller.FirstAbilitySpent ? _secondAbilityCost : _firstAbilityCost;
        }
        
        protected virtual void Start()
        {
            _controller = GetComponent<UnitController>();
        }
    }
}