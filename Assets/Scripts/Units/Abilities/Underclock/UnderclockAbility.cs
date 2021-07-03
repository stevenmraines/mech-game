using RainesGames.Common.Power;
using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities.Underclock
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class UnderclockAbility : AbsAbility, ICooldownManagerClient, IPowerManagerClient, IUnitTargetAbility
    {
        private CooldownManager _cooldownManager = new CooldownManager();
        private PowerManager _powerManager = new PowerManager();
        private Validator _validator = new Validator();

        public DataAbility Data;
        public DataCooldownAbility CooldownData;
        public DataPoweredAbility PowerData;
        public DataStatusAbility StatusData;

        public override bool CanBeUsed()
        {
            return IsAffordable() && IsPowered() && !NeedsCooldown();
        }

        public void Execute(AbsUnit targetUnit)
        {
            if(_validator.IsValid(_parentUnit, targetUnit))
            {
                targetUnit.Underclock(GetDuration());
                DecrementAbilityPoints();
                ResetCooldown();
            }
        }


        #region ABILITY DATA METHODS
        public override int GetFirstAbilityCost()
        {
            return Data.FirstAbilityCost;
        }

        public override int GetSecondAbilityCost()
        {
            return Data.SecondAbilityCost;
        }

        public override AudioClip GetSoundEffect()
        {
            return Data.SoundEffect;
        }

        public override UnitState GetState()
        {
            return Data.State;
        }

        public override bool ShowInTray()
        {
            return Data.ShowInTray;
        }
        #endregion


        #region COOLDOWN MANAGER
        public void Cooldown()
        {
            _cooldownManager.Cooldown();
        }

        public int GetCooldown()
        {
            return _cooldownManager.GetCooldown();
        }

        public int GetCooldownDuration()
        {
            return CooldownData.CooldownDuration;
        }

        public bool NeedsCooldown()
        {
            return _cooldownManager.GetCooldown() > 0;
        }

        public void ResetCooldown()
        {
            _cooldownManager.SetCooldown(CooldownData.CooldownDuration);
        }
        #endregion


        #region POWER MANAGER
        public void AddPower(int power)
        {
            _powerManager.AddPower(power, GetMaxPower());
        }

        public int GetMaxPower()
        {
            return PowerData.MaxPower;
        }

        public int GetMinPower()
        {
            return PowerData.MinPower;
        }

        public int GetPower()
        {
            return _powerManager.GetPower();
        }

        public bool IsPowered()
        {
            return GetPower() >= GetMinPower();
        }

        public void RemovePower(int power)
        {
            _powerManager.RemovePower(power);
        }
        #endregion


        #region STATUS
        public int GetDuration()
        {
            return StatusData.Duration;
        }
        #endregion
    }
}