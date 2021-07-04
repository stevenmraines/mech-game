using UnityEngine;

namespace RainesGames.Units.Usables.Abilities
{
    public class AbilityPointsManager : IAbilityPoints
    {
        private int _abilityPoints;
        private bool _firstAbilitySpent = false;

        public delegate void AbilityPointsDelegate();
        public event AbilityPointsDelegate OnDecrement;
        public static event AbilityPointsDelegate OnDecrementStatic;
        public event AbilityPointsDelegate OnForceSpendAll;
        public event AbilityPointsDelegate OnIncrement;
        public event AbilityPointsDelegate OnReset;

        public void Decrement(int points)
        {
            _abilityPoints = Mathf.Max(0, _abilityPoints - points);
            _firstAbilitySpent = true;

            OnDecrement?.Invoke();
            OnDecrementStatic?.Invoke();
        }

        public bool FirstAbilitySpent()
        {
            return _firstAbilitySpent;
        }

        public void ForceSpendAllAbilityPoints()
        {
            _abilityPoints = 0;
            _firstAbilitySpent = true;
            OnForceSpendAll?.Invoke();
        }

        public int GetAbilityPoints()
        {
            return _abilityPoints;
        }

        public void Increment(int points)
        {
            _abilityPoints += points;
            OnIncrement?.Invoke();
        }

        public void ResetAbilityPoints(int points)
        {
            _abilityPoints = Mathf.Max(0, points);
            _firstAbilitySpent = false;
            OnReset?.Invoke();
        }
    }
}