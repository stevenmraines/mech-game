using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnDeselect(GameObject selection)
    {
        Object.Destroy(selection.GetComponent<Outline>());
    }

    public void OnSelect(GameObject selection)
    {
        Outline outline = selection.AddComponent<Outline>() as Outline;
        outline.OutlineMode = UnitSelectionManager._outlineMode;
        outline.OutlineWidth = UnitSelectionManager._outlineWidth;
        outline.OutlineColor = UnitSelectionManager._enemyColor;

        if(selection.tag == "Player")
            outline.OutlineColor = UnitSelectionManager._playerColor;
    }
}
