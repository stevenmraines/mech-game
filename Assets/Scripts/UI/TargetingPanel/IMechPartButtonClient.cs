using RainesGames.Units;
using RainesGames.Units.Mechs.MechParts;

namespace RainesGames.UI.TargetingPanel
{
    public interface IMechPartButtonClient
    {
        void OnMechPartClick(IUnit activeUnit, IUnit targetUnit, IMechPart mechpart);
    }
}
