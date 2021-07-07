using RainesGames.Common.Power;
using RainesGames.Units.States;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.FactoryReset
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class FactoryResetAbility : AbsUsable, IAbility, ICooldownManagerClient, IFiniteUseManagerClient,
        IPowerManagerClient, IStatusAbility, IUnitTargetUsable
    {
        private CooldownManager _cooldownManager = new CooldownManager();
        private FiniteUseManager _finiteUseManager = new FiniteUseManager();
        private PowerManager _powerManager = new PowerManager();
        private Validator _validator = new Validator();

        public DataAbility AbilityData;
        public DataCooldownAbility CooldownData;
        public DataFiniteUseAbility FiniteUseData;
        public DataPoweredAbility PowerData;
        public DataStatusAbility StatusData;
        public DataUsable UsableData;

        protected override void Awake()
        {
            base.Awake();
            SetUsesRemaining();
        }

        public override bool CanBeUsed()
        {
            return IsAffordable() && IsPowered() && HasMoreUses() && !NeedsCooldown();
        }

        public void Use(IUnit targetUnit)
        {
            if(!_validator.IsValidTarget(_unit, targetUnit))
                return;

            targetUnit.FactoryReset(GetDuration());
            DecrementActionPoints();
            ResetCooldown();
            DecrementUsesRemaining();
        }


        #region ABILITY DATA METHODS
        public AudioClip GetSoundEffect()
        {
            return AbilityData.SoundEffect;
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


        #region FINITE USE MANAGER
        public void DecrementUsesRemaining()
        {
            _finiteUseManager.Decrement();
        }

        public int GetUsesRemaining()
        {
            return _finiteUseManager.GetUsesRemaining();
        }

        public bool HasMoreUses()
        {
            return GetUsesRemaining() > 0;
        }

        public void SetUsesRemaining()
        {
            _finiteUseManager.SetUsesRemaining(FiniteUseData.NumberOfUses);
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


        #region STATUS DATA METHODS
        public int GetDuration()
        {
            return StatusData.Duration;
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
    }
}