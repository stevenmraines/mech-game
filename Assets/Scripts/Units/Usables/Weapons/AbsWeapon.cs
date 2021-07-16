namespace RainesGames.Units.Usables.Weapons
{
    public abstract class AbsWeapon : AbsUsable, IWeapon
    {
        public DataWeapon WeaponData;

        public abstract float GetAccuracy();
        public abstract int GetBallisticDamage();
        public abstract int GetEMPDamage();
        public abstract int GetEnergyDamage();
        public abstract MountType GetMountType();
    }
}
