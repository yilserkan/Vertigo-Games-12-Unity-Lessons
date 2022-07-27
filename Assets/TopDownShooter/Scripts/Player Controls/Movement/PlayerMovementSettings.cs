using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;
        
        public float HorizontalSpeed { get { return horizontalSpeed; } }
        public float VerticalSpeed { get { return verticalSpeed; } }
    }

}
