using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.ReroutePower
{
    [DisallowMultipleComponent]
    public class ReroutePowerAbility : AbsUsable, IAbility, IActivatableUsable, IDeactivatableUsable, ITargetlessUsable
    {
        private ITargetlessUsableValidator _validator = new ReroutePowerValidator();

        public DataAbility AbilityData;
        public DataUsable UsableData;

        public void Activate()
        {
            _unit.RecordPowerState();
        }

        public override bool CanBeUsed()
        {
            return IsAffordable();
        }

        public void Deactivate()
        {
            _unit.RevertPowerState();
        }

        public void Use()
        {
            if(_validator.IsValid(_unit))
            {
                _unit.DiscardPowerState();
                DecrementActionPoints();
            }
        }


        #region ABILITY DATA METHODS
        public AudioClip GetSoundEffect()
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