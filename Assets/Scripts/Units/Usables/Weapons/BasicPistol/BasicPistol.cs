using System.Collections.Generic;
using RainesGames.Combat.States;
using RainesGames.UI;
using RainesGames.UI.TargetingPanel;
using RainesGames.Units.Mechs.MechParts;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Usables.Weapons.BasicPistol
{
    public class BasicPistol : AbsWeapon, IActivatableUsable, IActiveUnitEvents, IDeactivatableUsable,
        IMechPartButtonClient, IMechPartTargetUsable, IRangedUsable
    {
        private IWeaponActivationResponse _activationResponse = new DrawRangeActivationResponse();
        private IWeaponDeactivationResponse _deactivationResponse = new DrawRangeActivationResponse();
        private IMechPartTargetUsableValidator _mechPartValidator = new EnemyMechPartTargetValidator();
        private IWeaponRangeCellProvider _rangeCellProvider = new CircularWeaponRangeCellProvider();
        private IUnitTargetRangedUsableValidator _rangeValidator = new EnemyUnitTargetRangedValidator();
        private TargetingPanelController _targetingPanel;
        private IUnit _targetUnit;
        private IUnitTargetUsableValidator _unitValidator = new EnemyUnitTargetValidator();

        public DataRange RangeData;
        public DataUsable UsableData;


        #region MONOBEHAVIOUR METHODS
        void Start()
        {
            _targetingPanel = FindObjectOfType<HudUiController>()?.GetTargetingPanel();
        }

        void OnDisable()
        {
            HeadButtonController.OnButtonClickReroute -= OnMechPartClick;
            LeftArmButtonController.OnButtonClickReroute -= OnMechPartClick;
            LegsButtonController.OnButtonClickReroute -= OnMechPartClick;
            RightArmButtonController.OnButtonClickReroute -= OnMechPartClick;
            TorsoButtonController.OnButtonClickReroute -= OnMechPartClick;

            UnitEventRouter.OnUnitClickReroute -= OnActiveUnitClick;
            UnitEventRouter.OnUnitEnterReroute -= OnActiveUnitEnter;
            UnitEventRouter.OnUnitExitReroute -= OnActiveUnitExit;
        }

        void OnEnable()
        {
            HeadButtonController.OnButtonClickReroute += OnMechPartClick;
            LeftArmButtonController.OnButtonClickReroute += OnMechPartClick;
            LegsButtonController.OnButtonClickReroute += OnMechPartClick;
            RightArmButtonController.OnButtonClickReroute += OnMechPartClick;
            TorsoButtonController.OnButtonClickReroute += OnMechPartClick;

            UnitEventRouter.OnUnitClickReroute += OnActiveUnitClick;
            UnitEventRouter.OnUnitEnterReroute += OnActiveUnitEnter;
            UnitEventRouter.OnUnitExitReroute += OnActiveUnitExit;
        }
        #endregion


        #region MISC METHODS
        public void Activate()
        {
            _activationResponse.OnActivate(_unit, this);
        }

        public void Deactivate()
        {
            _targetingPanel.Hide();
            _deactivationResponse.OnDeactivate(_unit, this);
        }

        public bool IsValid(IUnit activeUnit, IUnit targetUnit)
        {
            return _unitValidator.IsValid(activeUnit, targetUnit) && _rangeValidator.IsValid(activeUnit, targetUnit, this);
        }

        public bool IsValid(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart)
        {
            return _mechPartValidator.IsValid(activeUnit, targetUnit, mechPart);
        }

        public void Use(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart)
        {
            if(!IsValid(activeUnit, targetUnit, mechPart))
                return;
            
            bool hitSuccessful = WeaponRNG.HitSuccessful(targetUnit, mechPart, this);

            if(hitSuccessful)
                mechPart.TakeDamage(GetBallisticDamage());

            if(!hitSuccessful)
                Debug.Log("Miss!");

            DecrementActionPoints();
        }
        #endregion


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


        #region UNIT/MECH PART METHODS
        public void OnActiveUnitClick(IUnit activeUnit, IUnit targetUnit, int buttonIndex)
        {
            if(!ShouldHandleEvent(activeUnit) || buttonIndex != 0)
                return;
            
            if(!IsValid(activeUnit, targetUnit))
                return;

            _targetUnit = targetUnit;
            _targetingPanel.SetUnits(activeUnit, _targetUnit);
            _targetingPanel.Show();
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

        public void OnMechPartClick(IUnit activeUnit, IUnit targetUnit, IMechPart mechpart)
        {
            if(!ShouldHandleEvent(activeUnit))
                return;

            // TODO This is kind of redundant now
            Use(activeUnit, targetUnit, mechpart);
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
