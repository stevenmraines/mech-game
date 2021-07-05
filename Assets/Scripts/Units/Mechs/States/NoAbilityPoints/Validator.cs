namespace RainesGames.Units.Mechs.States.NoAbilityPoints
{
    public class Validator : IStateTransitionValidator
    {
        public bool CanEnterState(MechController mech)
        {
            return mech.GetActionPoints() == 0;
        }
    }
}