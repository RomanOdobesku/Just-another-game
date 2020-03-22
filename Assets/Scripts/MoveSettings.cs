using System;

namespace Robot
{
    [Serializable]
    public class MoveSettings
    {
        public float MovePower = 25; // The force added to the ball to move it.
        public float MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        public float JumpPower = 5; // The force added to the ball when it jumps.
        public bool UseTorque = true; // Whether or not to use torque to move the ball.
    }
}
