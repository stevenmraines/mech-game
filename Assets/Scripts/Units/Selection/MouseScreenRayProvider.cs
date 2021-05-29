using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
    {
        private UnityEngine.Camera _mainCamera;

        void Awake()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        public Ray CreateRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}