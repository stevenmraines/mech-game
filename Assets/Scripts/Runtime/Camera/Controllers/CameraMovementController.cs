using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControllers
{
    public class CameraMovementController : MonoBehaviour
    {
        [SerializeField] private GameObject cameraTarget;
        [SerializeField] private float fovIncrement = 20f;
        [SerializeField] private float heightIncrement = 10f;
        [SerializeField] private float maxFov = 100f;
        [SerializeField] private float maxHeight = 30f;
        [SerializeField] private float minFov = 20f;
        [SerializeField] private float minHeight = 10f;
        [SerializeField] private float moveIncrement = 20f;
        [SerializeField] private float rotationDuration = 0.25f;

        const int leftDirection = -1;
        const int leftTurn = -90;
        const int lowerDirection = 1;
        const int raiseDirection = -1;
        const int rightDirection = 1;
        const int rightTurn = 90;
        const int zoomInDirection = -1;
        const int zoomOutDirection = 1;

        // Monobehavior methods
        void OnDisable()
        {
            CameraInputController.CameraLoweredEvent -= Lower;
            CameraInputController.CameraMovedEvent -= Move;
            CameraInputController.CameraRaisedEvent -= Raise;
            CameraInputController.CameraRotatedLeftEvent -= RotateLeft;
            CameraInputController.CameraRotatedRightEvent -= RotateRight;
            CameraInputController.CameraZoomedInEvent -= ZoomIn;
            CameraInputController.CameraZoomedOutEvent -= ZoomOut;
        }

        void OnEnable()
        {
            CameraInputController.CameraLoweredEvent += Lower;
            CameraInputController.CameraMovedEvent += Move;
            CameraInputController.CameraRaisedEvent += Raise;
            CameraInputController.CameraRotatedLeftEvent += RotateLeft;
            CameraInputController.CameraRotatedRightEvent += RotateRight;
            CameraInputController.CameraZoomedInEvent += ZoomIn;
            CameraInputController.CameraZoomedOutEvent += ZoomOut;
        }

        // Other methods
        private void ChangeHeight(int direction)
        {
            Vector3 change = new Vector3(0, heightIncrement * direction, 0);
            Vector3 newPosition = cameraTarget.transform.position += change;
            
            if(direction == lowerDirection)
            {
                Vector3 maxVector = new Vector3(cameraTarget.transform.position.x, maxHeight, cameraTarget.transform.position.z);
                newPosition = Vector3.Min(newPosition, maxVector);
            }

            if(direction == raiseDirection)
            {
                Vector3 minVector = new Vector3(cameraTarget.transform.position.x, minHeight, cameraTarget.transform.position.z);
                newPosition = Vector3.Max(newPosition, minVector);
            }

            cameraTarget.transform.position = newPosition;
        }

        private void Lower(CameraInputController input)
        {
            ChangeHeight(lowerDirection);
        }

        private void Move(CameraInputController input)
        {
            float horizontalAxisRaw = input.GetHorizontal();
            float verticalAxisRaw = input.GetVertical();
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            Vector3 right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
            Vector3 rightMovement = right * moveIncrement * Time.deltaTime * horizontalAxisRaw;
            Vector3 forwardMovement = forward * moveIncrement * Time.deltaTime * verticalAxisRaw;
            cameraTarget.transform.position += rightMovement;
            cameraTarget.transform.position += forwardMovement;
        }

        private void Raise(CameraInputController input)
        {
            ChangeHeight(raiseDirection);
        }

        IEnumerator Rotate(int turn)
        {
            float timeElapsed = 0;
            Quaternion startRotation = cameraTarget.transform.rotation;
            Quaternion endRotation = Quaternion.AngleAxis(turn, Vector3.up) * startRotation;

            while(timeElapsed < rotationDuration)
            {
                cameraTarget.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / rotationDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            cameraTarget.transform.rotation = endRotation;
        }

        private void RotateLeft(CameraInputController input)
        {
            StartCoroutine(Rotate(leftTurn));
        }

        private void RotateRight(CameraInputController input)
        {
            StartCoroutine(Rotate(rightTurn));
        }

        private void Zoom(int direction)
        {
            float newFov = Camera.main.fieldOfView + direction * fovIncrement;
            Camera.main.fieldOfView = direction < 0 ?
                Mathf.Max(minFov, newFov) :
                Mathf.Min(maxFov, newFov);
        }

        private void ZoomIn(CameraInputController input)
        {
            Zoom(zoomInDirection);
        }

        private void ZoomOut(CameraInputController input)
        {
            Zoom(zoomOutDirection);
        }
    }
}
