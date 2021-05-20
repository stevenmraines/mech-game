using System.Collections.Generic;
using UnityEngine;

public class VisibleUnitsProvider : MonoBehaviour, ISelectablesProvider
{
    [SerializeField] private Camera _mainCamera;

    private Vector3 _oldCameraPosition;
    private Quaternion _oldCameraRotation;
    private List<GameObject> _visibleUnits;
    private bool _firstCheck => _oldCameraPosition == null || _oldCameraRotation == null;

    void Awake()
    {
        _visibleUnits = new List<GameObject>();
    }

    private bool CameraMoved()
    {
        return !_oldCameraPosition.Equals(_mainCamera.transform.position)
            || _oldCameraRotation != _mainCamera.transform.rotation;
    }

    public List<GameObject> GetSelectables()
    {
        bool updateNotNeeded = !_firstCheck && !CameraMoved();

        UpdateCameraTransform();
        
        if(updateNotNeeded)
            return _visibleUnits;

        _visibleUnits = new List<GameObject>();

        for(int i = 0; i < UnitManager.Units.Length; i++)
        {
            if(IsVisible(UnitManager.Units[i].Renderer))
                _visibleUnits.Add(UnitManager.Units[i].gameObject);
        }

        return _visibleUnits;
    }

    private bool IsVisible(Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(
            GeometryUtility.CalculateFrustumPlanes(_mainCamera),
            renderer.bounds
        );
    }

    private void UpdateCameraTransform()
    {
        if(_oldCameraPosition == null)
            _oldCameraPosition = new Vector3(0, 0, 0);

        if(_oldCameraRotation == null)
            _oldCameraRotation = new Quaternion(0, 0, 0, 0);

        _oldCameraPosition.Set(
            _mainCamera.transform.position.x,
            _mainCamera.transform.position.y,
            _mainCamera.transform.position.z
        );

        _oldCameraRotation.Set(
            _mainCamera.transform.rotation.x,
            _mainCamera.transform.rotation.y,
            _mainCamera.transform.rotation.z,
            _mainCamera.transform.rotation.w
        );
    }
}
