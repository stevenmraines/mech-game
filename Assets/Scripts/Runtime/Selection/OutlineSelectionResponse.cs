using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnDeselect(GameObject currentSelection)
    {
        Object.Destroy(currentSelection.GetComponent<Outline>());
    }

    public void OnSelect(GameObject currentSelection)
    {
        Outline outline = currentSelection.AddComponent<Outline>() as Outline;
        outline.OutlineMode = UnitSelectionManager._outlineMode;
        outline.OutlineWidth = UnitSelectionManager._outlineWidth;
        outline.OutlineColor = UnitSelectionManager._enemyColor;

        if(currentSelection.tag == "Player")
            outline.OutlineColor = UnitSelectionManager._playerColor;
    }
}
