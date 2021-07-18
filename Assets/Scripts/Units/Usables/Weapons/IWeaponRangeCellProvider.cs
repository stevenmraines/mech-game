using System.Collections.Generic;

namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeaponRangeCellProvider
    {
        IList<int> GetCellsInRange(IUnit activeUnit, IRangedUsable rangedWeapon);
    }
}
