namespace RainesGames.Units.States
{
    public interface IUnitState
    {
        bool CanEnterState(UnitController unit);
        void EnterState(UnitController unit);
        void ExitState(UnitController unit);
    }
}