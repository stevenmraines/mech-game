using UnityEngine;

namespace RainesGames.Units.Selection
{
    // TODO Refactor this so that it's functionality is part of the current CombatState
    public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        public void OnDeselect(GameObject selection)
        {
            Destroy(selection.GetComponent<Outline>());
        }

        public void OnSelect(GameObject selection)
        {
            Outline outline = selection.AddComponent<Outline>() as Outline;
            outline.OutlineMode = UnitSelectionManager.OutlineMode;
            outline.OutlineWidth = UnitSelectionManager.OutlineWidth;
            outline.OutlineColor = UnitSelectionManager.EnemyColor;

            if(selection.tag.ToLower() == "player")
                outline.OutlineColor = UnitSelectionManager.PlayerColor;
        }
    }
}