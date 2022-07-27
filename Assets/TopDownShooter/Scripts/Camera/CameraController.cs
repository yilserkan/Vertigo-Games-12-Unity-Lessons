using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings settings;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform cameraTransform;

        private void Update()
        {
            CameraRotateFollow();
            CameraPositionFollow();
        }

        private void CameraRotateFollow()
        {
            cameraTransform.rotation = Quaternion.Lerp(
                cameraTransform.rotation,
                Quaternion.LookRotation((targetTransform.position - cameraTransform.position), Vector3.up),
                settings.RotationLerpSpeed * Time.deltaTime
                );
        }

        private void CameraPositionFollow()
        {
            cameraTransform.position = Vector3.Lerp(
                cameraTransform.position, 
                targetTransform.position + settings.OffsetPosition, 
                settings.PositionLerpSpeed * Time.deltaTime
                );
        }
    }

}
