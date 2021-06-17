using TGS;

namespace RainesGames.Units.Abilities
{
    public interface ICellAbilityValidator
    {
        bool IsValid(Cell targetCell);
    }
}