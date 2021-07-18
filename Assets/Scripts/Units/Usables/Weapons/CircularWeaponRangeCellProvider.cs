using System.Collections.Generic;
using System.Linq;
using RainesGames.Grid;
using TGS;

namespace RainesGames.Units.Usables.Weapons
{
    public class CircularWeaponRangeCellProvider : IWeaponRangeCellProvider
    {
        public IList<int> GetCellsInRange(IUnit activeUnit, IRangedUsable rangedWeapon)
        {
            Cell position = activeUnit.GetPosition();

            if(position == null)
                return new List<int>();

            int maxRange = rangedWeapon.GetMaxRange();
            int minRange = rangedWeapon.GetMinRange();

            IList<int> innerCircle = GridWrapper.GetFilledCircularRegion(position.index, minRange);
            IList<int> outerCircle = GridWrapper.GetFilledCircularRegion(position.index, maxRange);
            
            return new List<int>(outerCircle.Except(innerCircle));
        }
    }
}
