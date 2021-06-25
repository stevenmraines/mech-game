using RainesGames.Grid;

namespace RainesGames.Units.States
{
    public interface ICellTargetState
    {
        ICellEvents CellEventHandler { get; }
    }
}