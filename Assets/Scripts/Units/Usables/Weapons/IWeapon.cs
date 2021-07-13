namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeapon : IUsable
    {
        float GetAccuracy();
        MountType GetMountType();
    }
}
