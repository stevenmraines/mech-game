using RainesGames.Units.Abilities.ReroutePower;

namespace RainesGames.Units.Mechs.States.ReroutePower
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            ReroutePowerAbility ability = mech.GetAbility<ReroutePowerAbility>();
            return ability != null && ability.CanBeUsed();
        }
    }
}