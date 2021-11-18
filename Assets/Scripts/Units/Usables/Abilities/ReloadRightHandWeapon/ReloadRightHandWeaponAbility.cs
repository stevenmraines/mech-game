using RainesGames.Units.Mechs;
using RainesGames.Units.Usables.Weapons;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.ReloadRightHandWeapon
{
    [DisallowMultipleComponent]
    public class ReloadRightHandWeaponAbility : AbsUsable, IAbility
    {
        public DataAbility AbilityData;
        public DataUsable UsableData;


        #region MISC METHODS
        public override bool CanBeUsed()
        {
            IWeapon weapon = ((MechController)_unit)?.RightArm.GetHandheldWeapon();

            if(weapon == null || !(weapon is IAmmoWeapon))
                return false;

            IAmmoWeapon ammoWeapon = ((IAmmoWeapon)weapon);

            return IsAffordable() && ammoWeapon.CanReload();
        }

        public void Use()
        {
            IWeapon weapon = ((MechController)_unit)?.RightArm.GetHandheldWeapon();
            ((IAmmoWeapon)weapon).Reload();
            _unit.DecrementActionPoints(GetActionCost());
        }
        #endregion


        #region ABILITY DATA METHODS
        AudioClip IAbility.GetSoundEffect()
        {
            return AbilityData.SoundEffect;
        }
        #endregion


        #region USABLE DATA METHODS
        public override int GetFirstActionCost()
        {
            return UsableData.FirstActionCost;
        }

        public override string GetName()
        {
            IWeapon weapon = ((MechController)_unit)?.RightArm.GetHandheldWeapon();

            if(weapon == null || !(weapon is IAmmoWeapon))
                return UsableData.name;

            return "Reload " + weapon.GetName();
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
    }
}