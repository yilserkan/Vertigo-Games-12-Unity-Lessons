using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class TowerRotationController : MonoBehaviour
    {
        [SerializeField] private TowerRotationSettings rotationSettings;
        [SerializeField] private Transform tower;
        [SerializeField] private InputData rotationInput;

        private void Update()
        {
            tower.Rotate(0, rotationSettings.RotationSpeed * rotationInput.Horizontal, 0, Space.Self);
        }
    }

}
