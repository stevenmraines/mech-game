using UnityEngine;

namespace RainesGames.Units.Selection
{
    // TODO Refactor this so that it's functionality is part of the current CombatState
    public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        public void OnDeselect(AbsUnit unit)
        {
            Destroy(unit.GetComponent<Outline>());
        }

        public void OnSelect(AbsUnit unit)
        {
            Outline outline = unit.gameObject.AddComponent<Outline>();// as Outline;
            outline.OutlineMode = UnitSelectionManager.OutlineMode;
            outline.OutlineWidth = UnitSelectionManager.OutlineWidth;
            outline.OutlineColor = UnitSelectionManager.EnemyColor;

            if(unit.IsPlayer())
                outline.OutlineColor = UnitSelectionManager.PlayerColor;
        }
    }
}