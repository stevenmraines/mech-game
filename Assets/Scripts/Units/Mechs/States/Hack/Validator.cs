using RainesGames.Units.Abilities.Hack;

namespace RainesGames.Units.Mechs.States.Hack
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            HackAbility ability = mech.GetAbility<HackAbility>();
            return ability != null && ability.CanBeUsed();
        }
    }
}