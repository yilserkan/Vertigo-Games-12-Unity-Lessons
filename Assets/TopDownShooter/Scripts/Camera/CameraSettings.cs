using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [Header("Rotation")]
        [SerializeField] private float rotationLerpSpeed = 1;
        public float RotationLerpSpeed { get { return rotationLerpSpeed; } }
        
        [Header("Position")]
        [SerializeField] private Vector3 offsetPosition;
        public Vector3 OffsetPosition { get { return offsetPosition; } }
        
        [SerializeField] private float positionLerpSpeed = 1;
        public float PositionLerpSpeed { get { return positionLerpSpeed; } }
    }

}
