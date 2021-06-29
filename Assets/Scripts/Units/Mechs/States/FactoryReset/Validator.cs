using RainesGames.Units.Abilities.FactoryReset;

namespace RainesGames.Units.Mechs.States.FactoryReset
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            FactoryResetAbility ability = mech.GetAbility<FactoryResetAbility>();
            return ability != null && ability.IsAffordable() && ability.IsPowered();
        }
    }
}