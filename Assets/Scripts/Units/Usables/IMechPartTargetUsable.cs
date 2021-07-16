using RainesGames.Units.Mechs.MechParts;

namespace RainesGames.Units.Usables
{
    public interface IMechPartTargetUsable
    {
        void Use(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart);
    }
}
