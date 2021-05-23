using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelectionResponse
    {
        void OnDeselect(GameObject selection);
        void OnSelect(GameObject selection);
    }
}