using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [DisallowMultipleComponent]
    public class AbilityPointsManager : MonoBehaviour, IAbilityPoints, IAbilityPointsConfig
    {
        private int _abilityPoints;
        public int AbilityPoints => _abilityPoints;

        private bool _firstAbilitySpent = false;
        public bool FirstAbilitySpent => _firstAbilitySpent;

        private int _startOfTurnAbilityPoints = 2;
        public int StartOfTurnAbilityPoints => _startOfTurnAbilityPoints;

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

        public void ForceSpendAllAbilityPoints()
        {
            _abilityPoints = 0;
            _firstAbilitySpent = true;
            OnForceSpendAll?.Invoke();
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