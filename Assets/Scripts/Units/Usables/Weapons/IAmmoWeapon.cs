namespace RainesGames.Units.Usables.Weapons
{
    public interface IAmmoWeapon
    {
        bool CanReload();
        int GetClipsRemaining();
        int GetNumberOfClips();
        int GetShotsRemaining();
        int GetShotsPerClip();
        bool NeedsReload();
        void Reload();
    }
}