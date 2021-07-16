using RainesGames.Combat.States;
using RainesGames.Common.Power;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Underclock
{
    [DisallowMultipleComponent]
    public class UnderclockAbility : AbsUsable, IAbility, IActiveUnitEvents, ICooldownManagerClient,
        IPowerManagerClient, IStatusAbility, IUnitTargetUsable
    {
        private CooldownManager _cooldownManager = new CooldownManager();
        private PowerManager _powerManager = new PowerManager();
        private IUnitTargetUsableValidator _validator = new EnemyUnitTargetValidator();

        public DataAbility AbilityData;
        public DataCooldownAbility CooldownData;
        public DataPoweredAbility PowerData;
        public DataStatusAbility StatusData;
        public DataUsable UsableData;

        #region MISC METHODS
        public override bool CanBeUsed()
        {
            return IsAffordable() && IsPowered() && !NeedsCooldown();
        }

        public bool IsValid(IUnit activeUnit, IUnit targetUnit)
        {
            return _validator.IsValid(activeUnit, targetUnit);
        }

        public void Use(IUnit targetUnit)
        {
            if(IsValid(_unit, targetUnit))
            {
                targetUnit.Underclock(GetDuration());
                DecrementActionPoints();
                ResetCooldown();
            }
        }
        #endregion


        #region MONOBEHAVIOUR METHODS
        void OnDisable()
        {
            UnitEventRouter.OnUnitClickReroute -= OnActiveUnitClick;
            UnitEventRouter.OnUnitEnterReroute -= OnActiveUnitEnter;
            UnitEventRouter.OnUnitExitReroute -= OnActiveUnitExit;
        }

        void OnEnable()
        {
            UnitEventRouter.OnUnitClickReroute += OnActiveUnitClick;
            UnitEventRouter.OnUnitEnterReroute += OnActiveUnitEnter;
            UnitEventRouter.OnUnitExitReroute += OnActiveUnitExit;
        }
        #endregion


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


        #region UNIT METHODS
        public void OnActiveUnitClick(IUnit activeUnit, IUnit targetUnit, int buttonIndex)
        {
            if(!ShouldHandleEvent(activeUnit) || buttonIndex != 0)
                return;

            Use(targetUnit);
        }

        public void OnActiveUnitEnter(IUnit activeUnit, IUnit targetUnit)
        {
            if(_unit != activeUnit)
                return;
        }

        public void OnActiveUnitExit(IUnit activeUnit, IUnit targetUnit)
        {
            if(_unit != activeUnit)
                return;
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
    }
}