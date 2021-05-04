using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControllers
{
    public class CameraInputController : MonoBehaviour
    {
        public delegate void CameraInputDelegate(CameraInputController cameraInput);
        public static event CameraInputDelegate CameraLoweredEvent;
        public static event CameraInputDelegate CameraMovedEvent;
        public static event CameraInputDelegate CameraRaisedEvent;
        public static event CameraInputDelegate CameraRotatedLeftEvent;
        public static event CameraInputDelegate CameraRotatedRightEvent;
        public static event CameraInputDelegate CameraZoomedInEvent;
        public static event CameraInputDelegate CameraZoomedOutEvent;

        // Monobehavior methods
        void Update()
        {
            if(CameraMoved() && CameraMovedEvent != null)
                CameraMovedEvent(this);

            if(CameraRotatedLeft() && CameraRotatedLeftEvent != null)
                CameraRotatedLeftEvent(this);

            if(CameraRotatedRight() && CameraRotatedRightEvent != null)
                CameraRotatedRightEvent(this);

            if(CameraLowered() && CameraLoweredEvent != null)
                CameraLoweredEvent(this);

            if(CameraRaised() && CameraRaisedEvent != null)
                CameraRaisedEvent(this);

            if(CameraZoomedIn() && CameraZoomedInEvent != null)
                CameraZoomedInEvent(this);

            if(CameraZoomedOut() && CameraZoomedOutEvent != null)
                CameraZoomedOutEvent(this);
        }

        // Other methods
        private bool CameraLowered()
        {
            return GetScroll() > 0;
        }

        private bool CameraMoved()
        {
            Vector3 direction = new Vector3(GetHorizontal(), 0, GetVertical());
            return direction.magnitude > 0.1f;
        }

        private bool CameraRaised()
        {
            return GetScroll() < 0;
        }

        private bool CameraRotatedLeft()
        {
            return Input.GetKeyUp(KeyCode.Q);
        }

        private bool CameraRotatedRight()
        {
            return Input.GetKeyUp(KeyCode.E);
        }

        private bool CameraZoomedIn()
        {
            return Input.GetKeyUp(KeyCode.Z);
        }

        private bool CameraZoomedOut()
        {
            return Input.GetKeyUp(KeyCode.X);
        }

        // Getters and setters
        public float GetHorizontal()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        private float GetScroll()
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }

        public float GetVertical()
        {
            return Input.GetAxisRaw("Vertical");
        }
    }
}
