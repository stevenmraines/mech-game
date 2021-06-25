using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.States.ReroutePower
{
    public class ReroutePowerState : MonoBehaviour, IUnitState
    {
        public bool CanEnterState(UnitController unit)
        {
            ReroutePowerAbility rerouteAbility = unit.GetAbility<ReroutePowerAbility>();
            CancelReroutePowerAbility cancelRerouteAbility = unit.GetAbility<CancelReroutePowerAbility>();
            return rerouteAbility != null && cancelRerouteAbility != null && rerouteAbility.AbilityIsAffordable();
        }

        public void EnterState(UnitController unit)
        {
            unit.PowerManager.RecordOldState();
        }

        public void ExitState(UnitController unit)
        {
            unit.PowerManager.DiscardOldState();
        }
    }
}