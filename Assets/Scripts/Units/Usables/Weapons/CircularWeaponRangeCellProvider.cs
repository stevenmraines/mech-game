using System.Collections.Generic;
using System.Linq;
using RainesGames.Grid;
using TGS;

namespace RainesGames.Units.Usables.Weapons
{
    public class CircularWeaponRangeCellProvider : IWeaponRangeCellProvider
    {
        public IList<int> GetCellsInRange(Cell center, IRangedUsable rangedWeapon)
        {
            if(center == null)
                return new List<int>();

            int maxRange = rangedWeapon.GetMaxRange();
            int minRange = rangedWeapon.GetMinRange();

            IList<int> innerCircle = GridWrapper.GetFilledCircularRegion(center.index, minRange);
            IList<int> outerCircle = GridWrapper.GetFilledCircularRegion(center.index, maxRange);
            
            return new List<int>(outerCircle.Except(innerCircle));
        }
    }
}
