using RainesGames.Units.Abilities.Move;

namespace RainesGames.Units.Mechs.States.Move
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            MoveAbility ability = mech.GetAbility<MoveAbility>();
            return ability != null && ability.IsAffordable();  // && ability.IsPowered();
        }
    }
}