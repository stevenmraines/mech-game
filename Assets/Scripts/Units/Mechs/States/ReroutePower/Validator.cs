using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.Abilities.ReroutePower;

namespace RainesGames.Units.Mechs.States.ReroutePower
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            ReroutePowerAbility rerouteAbility = mech.GetAbility<ReroutePowerAbility>();
            CancelReroutePowerAbility cancelRerouteAbility = mech.GetAbility<CancelReroutePowerAbility>();
            return rerouteAbility != null && cancelRerouteAbility != null && rerouteAbility.IsAffordable();
        }
    }
}