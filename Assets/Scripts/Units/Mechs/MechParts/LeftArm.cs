namespace RainesGames.Units.Mechs.MechParts
{
    public class LeftArm : AbsMechPart
    {
        public DataArm ArmData;
        public DataHitPoints HitPointsData;
        public DataWeight WeightData;

        protected override void Awake()
        {
            base.Awake();
            _hitPointsManager.SetHitPoints(HitPointsData.MaxHitPoints);
        }

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
