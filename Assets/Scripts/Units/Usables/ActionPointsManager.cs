using UnityEngine;

namespace RainesGames.Units.Usables
{
    public class ActionPointsManager : IActionPoints
    {
        private int _actionPoints;
        private bool _firstActionSpent = false;

        public delegate void ActionPointsDelegate();
        public event ActionPointsDelegate OnDecrement;
        public static event ActionPointsDelegate OnDecrementStatic;
        public event ActionPointsDelegate OnForceSpendAll;
        public event ActionPointsDelegate OnIncrement;
        public event ActionPointsDelegate OnReset;

        public void Decrement(int points)
        {
            _actionPoints = Mathf.Max(0, _actionPoints - points);
            _firstActionSpent = true;

            OnDecrement?.Invoke();
            OnDecrementStatic?.Invoke();
        }

        public bool FirstActionSpent()
        {
            return _firstActionSpent;
        }

        public void ForceSpendAllActionPoints()
        {
            _actionPoints = 0;
            _firstActionSpent = true;
            OnForceSpendAll?.Invoke();
        }

        public int GetActionPoints()
        {
            return _actionPoints;
        }

        public void Increment(int points)
        {
            _actionPoints += points;
            OnIncrement?.Invoke();
        }

        public void ResetActionPoints(int points)
        {
            _actionPoints = Mathf.Max(0, points);
            _firstActionSpent = false;
            OnReset?.Invoke();
        }
    }
}