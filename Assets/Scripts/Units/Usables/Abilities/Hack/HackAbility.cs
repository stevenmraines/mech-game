using RainesGames.Combat.States;
using RainesGames.Common.Power;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Hack
{
    [DisallowMultipleComponent]
    public class HackAbility : AbsUsable, IAbility, IActiveUnitEvents, ICooldownManagerClient, IFiniteUseManagerClient,
        IPowerManagerClient, IStatusAbility, IUnitTargetUsable
    {
        private CooldownManager _cooldownManager = new CooldownManager();
        private FiniteUseManager _finiteUseManager = new FiniteUseManager();
        private PowerManager _powerManager = new PowerManager();
        private IUnitTargetUsableValidator _validator = new HackValidator();

        public DataAbility AbilityData;
        public DataCooldownAbility CooldownData;
        public DataFiniteUseAbility FiniteUseData;
        public DataPoweredAbility PowerData;
        public DataStatusAbility StatusData;
        public DataUsable UsableData;

        public override bool CanBeUsed()
        {
            return IsAffordable() && IsPowered() && HasMoreUses() && !NeedsCooldown();
        }

        public void Use(IUnit targetUnit)
        {
            if(!_validator.IsValid(_unit, targetUnit))
                return;

            targetUnit.Hack(GetDuration());
            DecrementActionPoints();
            ResetCooldown();
            DecrementUsesRemaining();
        }


        #region MONOBEHAVIOUR METHODS
        protected override void Awake()
        {
            base.Awake();
            SetUsesRemaining();
        }

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


        #region UNIT METHODS
        public void OnActiveUnitClick(IUnit activeUnit, IUnit targetUnit, int buttonIndex)
        {
            if(!ShouldHandleEvent(activeUnit) || buttonIndex != 0)
                return;

            Use(targetUnit);
        }

        public void OnActiveUnitEnter(IUnit activeUnit, IUnit targetUnit)
        {
            if(!ShouldHandleEvent(activeUnit))
                return;
        }

        public void OnActiveUnitExit(IUnit activeUnit, IUnit targetUnit)
        {
            if(!ShouldHandleEvent(activeUnit))
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