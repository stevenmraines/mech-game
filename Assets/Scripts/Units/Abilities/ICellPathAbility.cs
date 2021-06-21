using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public interface ICellPathAbility
    {
        void Execute(List<int> path);
    }
}