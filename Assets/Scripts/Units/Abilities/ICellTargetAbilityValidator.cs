using RainesGames.Units.Mechs;
using TGS;

namespace RainesGames.Units.Abilities
{
    public interface ICellTargetAbilityValidator
    {
        bool IsValid(Mechs.MechController parentUnit, Cell targetCell);
    }
}