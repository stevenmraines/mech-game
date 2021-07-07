using System.Collections.Generic;
using RainesGames.Grid;
using RainesGames.Units.States;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Usables.Weapons.BasicShortSword
{
    [DisallowMultipleComponent]
    public class BasicShortSword : AbsUsable, IWeapon, IRangedUsable, IUnitTargetUsable
    {
        public DataRange RangeData;
        public DataUsable UsableData;
        public DataWeapon WeaponData;

        public override bool CanBeUsed()
        {
            return IsAffordable();
        }
        
        public void Use(IUnit unit)
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

        public bool HasLOS(IUnit targetUnit)
        {
            return true;
        }

        public bool InRange(Cell targetCell)
        {
            IList<int> path = GridWrapper.FindPath(_unit.GetPosition().index, targetCell.index, true);
            return path.Count > GetMaxRange() || path.Count < GetMinRange();
        }

        public bool NeedsLOS()
        {
            return RangeData.NeedsLOS;
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

        public override UnitState GetState()
        {
            return UsableData.State;
        }

        public override bool ShowInTray()
        {
            return UsableData.ShowInTray;
        }
        #endregion


        #region WEAPON DATA METHODS
        public float GetAccuracy()
        {
            return WeaponData.Accuracy;
        }

        public MountType GetMountType()
        {
            return WeaponData.MountType;
        }

        public string GetWeaponName()
        {
            return WeaponData.WeaponName;
        }
        #endregion
    }
}
