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
        outline.OutlineMode = SelectionManager.OutlineMode;
        outline.OutlineWidth = SelectionManager.OutlineWidth;
        outline.OutlineColor = SelectionManager.EnemyColor;

        if(selection.tag.ToLower() == "player")
            outline.OutlineColor = SelectionManager.PlayerColor;
    }
}
