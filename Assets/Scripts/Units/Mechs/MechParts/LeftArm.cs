using RainesGames.Units.Usables.Weapons;
using UnityEngine;

namespace RainesGames.Units.Mechs.MechParts
{
    public class LeftArm : AbsMechPart
    {
        [SerializeField] public AbsWeapon _handheldWeapon;
        [SerializeField] public AbsWeapon _shoulderMountedWeapon;

        public DataArm ArmData;
        public DataHitPoints HitPointsData;
        public DataWeight WeightData;

        protected override void Awake()
        {
            base.Awake();
            _hitPointsManager.SetHitPoints(HitPointsData.MaxHitPoints);
        }


        #region MISC METHODS
        public AbsWeapon GetHandheldWeapon()
        {
            return _handheldWeapon;
        }

        public AbsWeapon GetShoulderMountedWeapon()
        {
            return _shoulderMountedWeapon;
        }

        public void SetHandheldWeapon(AbsWeapon weapon)
        {
            if(weapon.GetMountType() != MountType.SINGLE_HANDED && weapon.GetMountType() != MountType.TWO_HANDED)
                return;

            gameObject.AddComponent(weapon.GetType());
            _handheldWeapon = weapon;
        }

        public void SetShoulderMountedWeapon(AbsWeapon weapon)
        {
            if(!HasShoulderMount() || weapon.GetMountType() != MountType.SHOULDER_MOUNTED)
                return;

            gameObject.AddComponent(weapon.GetType());
            _shoulderMountedWeapon = weapon;
        }
        #endregion


        #region ARM METHODS
        public virtual bool HasShoulderMount()
        {
            return ArmData.HasLeftShoulderMount;
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
