namespace RainesGames.Units.States
{
    public interface IUnitStateManagerClient
    {
        bool CanEnterState(UnitState state);
        UnitState GetCurrentState();
        bool HasCellEventHandler();
        bool HasCellEventHandler(UnitState state);
        bool HasUnitEventHandler();
        bool HasUnitEventHandler(UnitState state);
        void TransitionToState(UnitState state);
    }
}