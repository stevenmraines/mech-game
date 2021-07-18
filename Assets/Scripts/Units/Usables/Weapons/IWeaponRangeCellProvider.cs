using System.Collections.Generic;
using TGS;

namespace RainesGames.Units.Usables.Weapons
{
    public interface IWeaponRangeCellProvider
    {
        IList<int> GetCellsInRange(Cell center, IRangedUsable rangedWeapon);
    }
}
