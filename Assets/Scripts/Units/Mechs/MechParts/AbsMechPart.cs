using UnityEngine;

namespace RainesGames.Units.Mechs.MechParts
{
    public abstract class AbsMechPart : MonoBehaviour, IMechPart
    {
        protected HitPointsManager _hitPointsManager;

        protected virtual void Awake()
        {
            _hitPointsManager = new HitPointsManager();
        }

        public abstract int GetHitPoints();
        
        public abstract int GetMaxHitPoints();

        public abstract void Repair(int hitPoints);

        public abstract void TakeDamage(int hitPoints);
    }
}
