namespace RainesGames.Units.Usables.Weapons
{
    public interface IAmmoWeapon
    {
        int GetClipsRemaining();
        int GetNumberOfClips();
        int GetShotsRemaining();
        int GetShotsPerClip();
        void Reload();
    }
}