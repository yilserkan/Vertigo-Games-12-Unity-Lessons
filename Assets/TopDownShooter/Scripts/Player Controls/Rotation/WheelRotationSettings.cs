using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player/Wheel Rotation Settings")]
    public class WheelRotationSettings : ScriptableObject
    {
        public float WheelRotationSpeed = 1f;
    }

}

