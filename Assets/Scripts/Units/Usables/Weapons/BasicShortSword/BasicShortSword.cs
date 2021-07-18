using System.Collections.Generic;
using RainesGames.Units.Mechs.MechParts;
using TGS;

namespace RainesGames.Units.Usables.Weapons.BasicShortSword
{
    public class BasicShortSword : AbsWeapon, IRangedUsable
    {
        private IWeaponRangeCellProvider _rangeCellProvider = new CircularWeaponRangeCellProvider();

        public DataRange RangeData;
        public DataUsable UsableData;

        public void Use(IUnit unit, IList<IMechPart> mechParts)
        {

        }


        #region RANGED USABLE METHODS
        public IList<int> GetCellsInRange()
        {
            return _rangeCellProvider.GetCellsInRange(_unit.GetPosition(), this);
        }

        public int GetMaxRange()
        {
            return RangeData.MaxRange;
        }

        public int GetMinRange()
        {
            return RangeData.MinRange;
        }

        public bool InRange(Cell targetCell)
        {
            return GetCellsInRange().Contains(targetCell.index);
        }
        #endregion


        #region USABLE DATA METHODS
        public override int GetFirstActionCost()
        {
            return UsableData.FirstActionCost;
        }

        public override string GetName()
        {
            return UsableData.UsableName;
        }

        public override int GetSecondActionCost()
        {
            return UsableData.SecondActionCost;
        }

        public override bool NeedsLOS()
        {
            return UsableData.NeedsLOS;
        }

        public override bool ShowInTray()
        {
            return UsableData.ShowInTray;
        }
        #endregion


        #region WEAPON DATA METHODS
        public override float GetAccuracy()
        {
            return WeaponData.Accuracy;
        }

        public override int GetBallisticDamage()
        {
            return WeaponData.BallisticDamage;
        }

        public override int GetEMPDamage()
        {
            return WeaponData.EMPDamage;
        }

        public override int GetEnergyDamage()
        {
            return WeaponData.EnergyDamage;
        }

        public override MountType GetMountType()
        {
            return WeaponData.MountType;
        }
        #endregion
    }
}
