using RainesGames.Grid;
using RainesGames.Units.Mechs.MechParts;
using TGS;

namespace RainesGames.Units.Usables.Weapons.BasicPistol
{
    public class BasicPistol : AbsWeapon, IRangedUsable
    {
        public DataRange RangeData;
        public DataUsable UsableData;

        public void Use(IUnit unit, IMechPart mechPart)
        {

        }


        #region RANGED USABLE METHODS
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
            return GridWrapper.PathIsWithinRange(_unit.GetPosition().index, targetCell.index, GetMinRange(), GetMaxRange(), true);
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

        public override MountType GetMountType()
        {
            return WeaponData.MountType;
        }
        #endregion
    }
}
