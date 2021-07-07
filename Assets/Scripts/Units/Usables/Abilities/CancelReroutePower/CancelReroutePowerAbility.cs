﻿using RainesGames.Units.States;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.CancelReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class CancelReroutePowerAbility : AbsUsable, IAbility
    {
        public DataAbility AbilityData;
        public DataUsable UsableData;

        public override bool CanBeUsed()
        {
            return IsAffordable() && _unit.HasAbility<ReroutePowerAbility>();
        }

        public void Execute()
        {
            _unit.RevertPowerState();

            // Cancelling a power reroute costs no AP, but calling this triggers the unit state change
            DecrementActionPoints();
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