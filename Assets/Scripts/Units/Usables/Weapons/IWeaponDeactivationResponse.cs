namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeaponDeactivationResponse
    {
        void OnDeactivate(IUnit activeUnit, IWeapon weapon);
    }
}
