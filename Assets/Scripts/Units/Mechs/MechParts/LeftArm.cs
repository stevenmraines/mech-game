using RainesGames.Units.Usables.Weapons;

namespace RainesGames.Units.Mechs.MechParts
{
    public class LeftArm : AbsMechPart
    {
        protected IWeapon _oneHandedWeapon;
        protected IWeapon _twoHandedWeapon;
        protected IWeapon _shoulderMountedWeapon;

        public DataArm ArmData;
        public DataHitPoints HitPointsData;
        public DataWeight WeightData;

        protected override void Awake()
        {
            base.Awake();
            _hitPointsManager.SetHitPoints(HitPointsData.MaxHitPoints);
        }


        #region MISC METHODS
        public IWeapon GetHandheldWeapon()
        {
            return GetTwoHandedWeapon() != null ? GetTwoHandedWeapon() : GetOneHandedWeapon();
        }

        public IWeapon GetOneHandedWeapon()
        {
            return _oneHandedWeapon;
        }

        public IWeapon GetTwoHandedWeapon()
        {
            return _twoHandedWeapon;
        }

        public IWeapon GetShoulderMountedWeapon()
        {
            return _shoulderMountedWeapon;
        }

        public void SetOneHandedWeapon(IWeapon weapon)
        {
            _oneHandedWeapon = weapon;
        }

        public void SetTwoHandedWeapon(IWeapon weapon)
        {
            _twoHandedWeapon = weapon;
        }

        public void SetShoulderMountedWeapon(IWeapon weapon)
        {
            _shoulderMountedWeapon = weapon;
        }
        #endregion


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


        #region WEIGHT METHODS
        public int GetWeight()
        {
            return WeightData.Weight;
        }
        #endregion
    }
}
