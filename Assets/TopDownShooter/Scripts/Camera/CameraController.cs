using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings settings;
        [SerializeField] private Transform rotationTarget;
        [SerializeField] private Transform positionTarget;
        [SerializeField] private Transform cameraTransform;

        private void Update()
        {
            CameraPositionFollow();
            CameraRotateFollow();
        }

        private void CameraRotateFollow()
        {
            cameraTransform.rotation = Quaternion.Lerp(
                cameraTransform.rotation,
                Quaternion.LookRotation(rotationTarget.forward),
                settings.RotationLerpSpeed * Time.deltaTime
                );
        }

        private void CameraPositionFollow()
        {
            cameraTransform.localPosition = settings.OffsetPosition;
        }
    }

}
