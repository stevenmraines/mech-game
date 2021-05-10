using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    public Ray CreateRay()
    {
        return mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}
