using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public Ray CreateRay()
    {
        return _mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}
