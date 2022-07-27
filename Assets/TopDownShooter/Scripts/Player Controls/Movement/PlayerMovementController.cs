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
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        private void Update()
        {
            _rigidbody.MovePosition(_rigidbody.position + 
                                    (inputData.Vertical * _playerMovementSettings.VerticalSpeed * _rigidbody.transform.forward));
            _rigidbody.MovePosition(_rigidbody.position + 
                                    (inputData.Horizontal * _playerMovementSettings.HorizontalSpeed * _rigidbody.transform.right));
        }
    }

}
