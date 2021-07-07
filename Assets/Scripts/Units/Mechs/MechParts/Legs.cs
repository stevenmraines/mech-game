using UnityEngine;

namespace RainesGames.Units.Mechs.MechParts
{
    [DisallowMultipleComponent]
    public class Legs : AbsMechPart
    {
        public DataHitPoints HitPointsData;
        public DataLegs LegsData;
        public DataWeight WeightData;

        protected override void Awake()
        {
            base.Awake();
            _hitPointsManager.SetHitPoints(HitPointsData.MaxHitPoints);
        }

        public int GetMaxWeight()
        {
            return LegsData.MaxWeight;
        }

        // TODO Move all these kinds of methods into some kind of IDataClient interfaces
        public int GetWeight()
        {
            return WeightData.Weight;
        }


        #region HIT POINTS MANAGER
        public override int GetHitPoints()
        {
            return _hitPointsManager.GetHitPoints();
        }

        public override int GetMaxHitPoints()
        {
            return HitPointsData.MaxHitPoints;
        }

        public override void Repair(int hitPoints)
        {
            _hitPointsManager.Repair(hitPoints, GetMaxHitPoints());
        }

        public override void TakeDamage(int hitPoints)
        {
            _hitPointsManager.TakeDamage(hitPoints);
        }
        #endregion
    }
}
