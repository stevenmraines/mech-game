using UnityEngine;

namespace RainesGames.Units.Usables
{
    [RequireComponent(typeof(AbsUnit))]
    public abstract class AbsUsable : MonoBehaviour, IUsable
    {
        /*
         * Some tight coupling between usables and units should be okay,
         * since every usable will belong to a particular unit.
         */
        protected IUnit _unit;

        public abstract int GetFirstActionCost();
        public abstract string GetName();
        public abstract int GetSecondActionCost();
        public abstract bool ShowInTray();
        
        protected virtual void Awake()
        {
            _unit = GetComponent<IUnit>();
        }

        public virtual bool CanBeUsed()
        {
            return IsAffordable();
        }

        protected virtual void DecrementActionPoints()
        {
            _unit.DecrementActionPoints(GetActionCost());
        }

        public virtual int GetActionCost()
        {
            return _unit.FirstActionSpent() ? GetSecondActionCost() : GetFirstActionCost();
        }

        public virtual bool IsAffordable()
        {
            return _unit.GetActionPoints() >= GetActionCost();
        }
    }
}
