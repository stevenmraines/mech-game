using UnityEngine;

public interface ISelectionResponse
{
    void OnDeselect(GameObject selection);
    void OnSelect(GameObject selection);
}
