using UnityEngine;

namespace RainesGames.Selection
{
    public interface ISelectionResponse
    {
        void OnDeselect(GameObject selection);
        void OnSelect(GameObject selection);
    }
}