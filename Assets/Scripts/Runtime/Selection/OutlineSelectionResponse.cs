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
        outline.OutlineMode = SelectionManager._outlineMode;
        outline.OutlineWidth = SelectionManager._outlineWidth;
        outline.OutlineColor = SelectionManager._enemyColor;

        if(selection.tag == "Player")
            outline.OutlineColor = SelectionManager._playerColor;
    }
}
