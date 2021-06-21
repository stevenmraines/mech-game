using TGS;

namespace RainesGames.Units.Abilities.Move.Path
{
    public interface ICellSelectionResponse
    {
        void OnDeselect(TerrainGridSystem sender, int cellIndex);
        void OnSelect(TerrainGridSystem sender, int cellIndex);
    }
}