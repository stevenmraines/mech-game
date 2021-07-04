using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Usables
{
    public abstract class AbsUsable : MonoBehaviour, IUsable
    {
        protected IUnit _unit;

        public abstract bool CanBeUsed();
        public abstract int GetFirstActionCost();
        public abstract string GetName();
        public abstract int GetSecondActionCost();
        public abstract UnitState GetState();
        public abstract bool ShowInTray();

        protected virtual void DecrementActionPoints()
        {
            _unit.DecrementAbilityPoints(GetActionCost());
        }

        public virtual int GetActionCost()
        {
            return _unit.FirstAbilitySpent() ? GetSecondActionCost() : GetFirstActionCost();
        }

        public virtual bool IsAffordable()
        {
            return _unit.GetAbilityPoints() >= GetActionCost();
        }
    }
}
