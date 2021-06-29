namespace RainesGames.Units.Mechs.States
{
    public interface IStateChangeEvents
    {
        void OnEnterState(AbsUnit mech);
        void OnExitState(AbsUnit mech);
    }
}