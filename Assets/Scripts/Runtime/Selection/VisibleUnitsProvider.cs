using System.Collections.Generic;
using UnityEngine;

public class VisibleUnitsProvider : MonoBehaviour, ISelectablesProvider
{
    private Camera _mainCamera;
    private Vector3 _oldCameraPosition;
    private Quaternion _oldCameraRotation;
    private List<GameObject> _visibleUnits;
    private bool _firstCheck => _oldCameraPosition == null || _oldCameraRotation == null;

    void Awake()
    {
        _mainCamera = Camera.main;
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

        UnitController[] units = FindObjectsOfType<UnitController>();

        for(int i = 0; i < units.Length; i++)
        {
            if(IsVisible(units[i].GetComponent<Renderer>()))
                _visibleUnits.Add(units[i].gameObject);
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

        _oldCameraPosition.x = _mainCamera.transform.position.x;
        _oldCameraPosition.y = _mainCamera.transform.position.y;
        _oldCameraPosition.z = _mainCamera.transform.position.z;

        _oldCameraRotation.x = _mainCamera.transform.rotation.x;
        _oldCameraRotation.y = _mainCamera.transform.rotation.y;
        _oldCameraRotation.z = _mainCamera.transform.rotation.z;
        _oldCameraRotation.w = _mainCamera.transform.rotation.w;
    }
}
