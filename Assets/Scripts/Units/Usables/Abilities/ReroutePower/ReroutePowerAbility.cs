using RainesGames.Units.States;
using RainesGames.Units.Usables.Abilities.CancelReroutePower;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.ReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CancelReroutePowerAbility))]
    public class ReroutePowerAbility : AbsUsable, IAbility, ITargetlessAbility
    {
        private Validator _validator = new Validator();

        public DataAbility AbilityData;
        public DataUsable UsableData;

        public override bool CanBeUsed()
        {
            return IsAffordable() && _unit.HasAbility<CancelReroutePowerAbility>();
        }

        public void Execute()
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