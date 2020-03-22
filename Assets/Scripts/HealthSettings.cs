using System;

namespace Robot
{
    [Serializable]
    public class HealthSettings
    {
        public float MaxHealth = 100; // Max robot's health
        public float Health = 100; // current robot's health
        public int Group = 0; // robot's group (in order to define robot's team)
        public float Height = 3;  // health bar height above the robot
        public float DamagePerSecond = 0.1f; // damage that the robot takes every second.
        public bool DynamicHealthBarCreate = true; // show/hide health bar 
    }
}
