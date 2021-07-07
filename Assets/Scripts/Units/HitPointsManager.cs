using UnityEngine;

namespace RainesGames.Units
{
    public class HitPointsManager
    {
        private int _hitPoints;

        public int GetHitPoints()
        {
            return _hitPoints;
        }

        public void Repair(int hitPoints, int maxHitPoints)
        {
            _hitPoints = Mathf.Min(maxHitPoints, _hitPoints + hitPoints);
        }

        public void SetHitPoints(int hitPoints)
        {
            _hitPoints = hitPoints;
        }

        public void TakeDamage(int hitPoints)
        {
            _hitPoints = Mathf.Max(0, _hitPoints - hitPoints);
        }
    }
}
