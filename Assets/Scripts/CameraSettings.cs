using System;

namespace Robot
{
    [Serializable]
    public class CameraSettings
    {
        public float MoveSpeed = 100; // speed of the camera behind the subject
        public float MaxAngleY = 90; // maximum vertical angle
        public float MinAngleY = -90; // minimum vertical angle
        public float HorizontalSensivity = 150; // horizontal mouse sensitivity
        public float VerticalSensivity = 150; // vertical mouse sensitivity
        public float MouseWheelSensivity = 1500; // scrollWheel mouse sensivity 
        public float MinDistance = 1; // minimum distance from the subject to the camera
        public float TargetDistance = 25; // desired distance from the subject to the camera 
        public float MaxDistance = 50; // maximum distance from the subject to the camera
        public float Smooth = 50; // smoothing camera movement in collisions
        public bool LockCursor = true; // hide/show cursor
    }
}
