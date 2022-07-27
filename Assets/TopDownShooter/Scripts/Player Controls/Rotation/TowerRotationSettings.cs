using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player/Rotation Settings")]
    
    public class TowerRotationSettings : ScriptableObject
    {
        public float RotationSpeed = 1f;
    }

}
