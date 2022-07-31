using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class WheelRotationController : MonoBehaviour
    {
        [SerializeField] private AbstractInputData movementInput;
        [SerializeField] private WheelRotationSettings wheelRotationSettings;
        
        [SerializeField] private Transform[] rightWheels;
        [SerializeField] private Transform[] leftWheels;
        
        
        private void Update()
        {
            for (int i = 0; i < rightWheels.Length; i++)
            {
                rightWheels[i].Rotate(
                    wheelRotationSettings.WheelRotationSpeed * movementInput.Vertical,
                    0,
                    0,
                    Space.Self
                    );
            }
            for (int i = 0; i < leftWheels.Length; i++)
            {
                leftWheels[i].Rotate(
                    wheelRotationSettings.WheelRotationSpeed * movementInput.Vertical,
                    0,
                    0,
                    Space.Self
                );
            }
        }
    }

}
