using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    [SerializeField] private Camera _mainCamera;

    public Ray CreateRay()
    {
        return _mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}
