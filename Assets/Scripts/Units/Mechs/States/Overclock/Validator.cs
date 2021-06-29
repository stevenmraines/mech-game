using RainesGames.Units.Abilities.Overclock;

namespace RainesGames.Units.Mechs.States.Overclock
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            OverclockAbility ability = mech.GetAbility<OverclockAbility>();
            return ability != null && ability.IsAffordable() && ability.IsPowered();
        }
    }
}