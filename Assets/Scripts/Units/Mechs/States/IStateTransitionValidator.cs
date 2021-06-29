namespace RainesGames.Units.Mechs.States
{
    public interface IStateTransitionValidator
    {
        bool CanEnterState(MechController mech);
    }
}