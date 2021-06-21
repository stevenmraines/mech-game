using System.Collections.Generic;

namespace RainesGames.Units.Abilities.Move.Path
{
    public interface IPathProvider
    {
        List<int> GetPath(int startCell, int endCell);
    }
}