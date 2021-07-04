using TGS;

namespace RainesGames.Units.Usables.Abilities
{
    public interface ICellTargetAbilityValidator
    {
        bool IsValid(Mechs.MechController parentUnit, Cell targetCell);
    }
}