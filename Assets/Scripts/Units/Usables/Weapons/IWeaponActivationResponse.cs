namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeaponActivationResponse
    {
        void OnActivate(IUnit activeUnit, IWeapon weapon);
    }
}
