using RainesGames.Units.Mechs.MechParts;

namespace RainesGames.Units.Usables
{
    public interface IMechPartTargetUsableValidator
    {
        bool IsValid(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart);
    }
}
