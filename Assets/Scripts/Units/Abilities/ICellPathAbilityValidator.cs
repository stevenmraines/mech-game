using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public interface ICellPathAbilityValidator
    {
        bool IsValid(List<int> path);
    }
}