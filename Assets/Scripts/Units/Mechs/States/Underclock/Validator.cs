using RainesGames.Units.Abilities.Underclock;

namespace RainesGames.Units.Mechs.States.Underclock
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            UnderclockAbility ability = mech.GetAbility<UnderclockAbility>();
            return ability != null && ability.IsAffordable() && ability.IsPowered();
        }
    }
}