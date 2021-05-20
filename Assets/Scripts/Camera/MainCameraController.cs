using System.Collections;
using UnityEngine;

namespace RainesGames.Camera
{
    public class MainCameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _cameraTarget;
        [SerializeField] private UnityEngine.Camera _mainCamera;
        [SerializeField] private float _fovIncrement = 20f;
        [SerializeField] private float _heightIncrement = 10f;
        [SerializeField] private float _maxFov = 100f;
        [SerializeField] private float _maxHeight = 30f;
        [SerializeField] private float _minFov = 20f;
        [SerializeField] private float _minHeight = 10f;
        [SerializeField] private float _moveIncrement = 20f;
        [SerializeField] private float _rotationDuration = 0.25f;

        const int LEFT_TURN = -90;
        const int LOWER_DIRECTION = 1;
        const int RAISE_DIRECTION = -1;
        const int RIGHT_TURN = 90;
        const int ZOOM_IN_DIRECTION = -1;
        const int ZOOM_OUT_DIRECTION = 1;

        // Monobehavior methods
        void OnDisable()
        {
            MainCameraInputManager.CameraLoweredEvent -= Lower;
            MainCameraInputManager.CameraMovedEvent -= Move;
            MainCameraInputManager.CameraRaisedEvent -= Raise;
            MainCameraInputManager.CameraRotatedLeftEvent -= RotateLeft;
            MainCameraInputManager.CameraRotatedRightEvent -= RotateRight;
            MainCameraInputManager.CameraZoomedInEvent -= ZoomIn;
            MainCameraInputManager.CameraZoomedOutEvent -= ZoomOut;
        }

        void OnEnable()
        {
            MainCameraInputManager.CameraLoweredEvent += Lower;
            MainCameraInputManager.CameraMovedEvent += Move;
            MainCameraInputManager.CameraRaisedEvent += Raise;
            MainCameraInputManager.CameraRotatedLeftEvent += RotateLeft;
            MainCameraInputManager.CameraRotatedRightEvent += RotateRight;
            MainCameraInputManager.CameraZoomedInEvent += ZoomIn;
            MainCameraInputManager.CameraZoomedOutEvent += ZoomOut;
        }

        // Other methods
        private void ChangeHeight(int direction)
        {
            Vector3 change = new Vector3(0, _heightIncrement * direction, 0);
            Vector3 newPosition = _cameraTarget.transform.position += change;
            
            if(direction == LOWER_DIRECTION)
            {
                Vector3 maxVector = new Vector3(_cameraTarget.transform.position.x, _maxHeight, _cameraTarget.transform.position.z);
                newPosition = Vector3.Min(newPosition, maxVector);
            }

            if(direction == RAISE_DIRECTION)
            {
                Vector3 minVector = new Vector3(_cameraTarget.transform.position.x, _minHeight, _cameraTarget.transform.position.z);
                newPosition = Vector3.Max(newPosition, minVector);
            }

            _cameraTarget.transform.position = newPosition;
        }

        private void Lower(MainCameraInputManager input)
        {
            ChangeHeight(LOWER_DIRECTION);
        }

        private void Move(MainCameraInputManager input)
        {
            float horizontalAxisRaw = input.GetHorizontal();
            float verticalAxisRaw = input.GetVertical();
            Vector3 forward = _mainCamera.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            Vector3 right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
            Vector3 rightMovement = right * _moveIncrement * Time.deltaTime * horizontalAxisRaw;
            Vector3 forwardMovement = forward * _moveIncrement * Time.deltaTime * verticalAxisRaw;
            _cameraTarget.transform.position += rightMovement;
            _cameraTarget.transform.position += forwardMovement;
        }

        private void Raise(MainCameraInputManager input)
        {
            ChangeHeight(RAISE_DIRECTION);
        }

        IEnumerator Rotate(int turn)
        {
            float timeElapsed = 0;
            Quaternion startRotation = _cameraTarget.transform.rotation;
            Quaternion endRotation = Quaternion.AngleAxis(turn, Vector3.up) * startRotation;

            while(timeElapsed < _rotationDuration)
            {
                _cameraTarget.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / _rotationDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            _cameraTarget.transform.rotation = endRotation;
        }

        private void RotateLeft(MainCameraInputManager input)
        {
            StartCoroutine(Rotate(LEFT_TURN));
        }

        private void RotateRight(MainCameraInputManager input)
        {
            StartCoroutine(Rotate(RIGHT_TURN));
        }

        private void Zoom(int direction)
        {
            float newFov = _mainCamera.fieldOfView + direction * _fovIncrement;
            _mainCamera.fieldOfView = direction < 0 ?
                Mathf.Max(_minFov, newFov) :
                Mathf.Min(_maxFov, newFov);
        }

        private void ZoomIn(MainCameraInputManager input)
        {
            Zoom(ZOOM_IN_DIRECTION);
        }

        private void ZoomOut(MainCameraInputManager input)
        {
            Zoom(ZOOM_OUT_DIRECTION);
        }
    }
}
