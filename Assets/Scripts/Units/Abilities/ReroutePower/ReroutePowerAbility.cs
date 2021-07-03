using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities.ReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CancelReroutePowerAbility))]
    public class ReroutePowerAbility : AbsAbility, ITargetlessAbility
    {
        private Validator _validator = new Validator();

        public DataAbility Data;

        public override bool CanBeUsed()
        {
            return IsAffordable() && _parentUnit.HasAbility<CancelReroutePowerAbility>();
        }

        public void Execute()
        {
            if(_validator.IsValid(_parentUnit))
            {
                _parentUnit.DiscardPowerState();
                DecrementAbilityPoints();
            }
        }

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
    }
}