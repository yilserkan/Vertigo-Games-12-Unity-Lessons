using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputData inputData;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        public void InitializeInputData(InputData inputData)
        {
            this.inputData = inputData;
        }
        
        private void Update()
        {
            _rigidbody.MovePosition(_rigidbody.position + 
                                    (inputData.Vertical * _playerMovementSettings.VerticalSpeed * targetTransform.transform.forward));
            targetTransform.Rotate(0,_playerMovementSettings.HorizontalSpeed * inputData.Horizontal,0, Space.Self);
        }
    }

}
