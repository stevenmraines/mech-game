using TGS;

namespace RainesGames.Units.Abilities
{
    public interface ICellTargetAbilityValidator
    {
        bool IsValid(UnitController parentUnit, Cell targetCell);
    }
}