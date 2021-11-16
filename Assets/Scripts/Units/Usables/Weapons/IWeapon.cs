
namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeapon : IUsable
    {
        float GetAccuracy();
        int GetBallisticDamage();
        int GetEnergyDamage();
        int GetEMPDamage();
        MountType GetMountType();
    }
}
