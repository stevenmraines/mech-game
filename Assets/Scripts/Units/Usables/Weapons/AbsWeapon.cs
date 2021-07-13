namespace RainesGames.Units.Usables.Weapons
{
    public abstract class AbsWeapon : AbsUsable, IWeapon
    {
        public DataWeapon WeaponData;

        public abstract float GetAccuracy();
        public abstract MountType GetMountType();
    }
}
