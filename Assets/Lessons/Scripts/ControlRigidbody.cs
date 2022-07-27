using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons
{
    public class ControlRigidbody : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ControlRigidbodySettings _settings;

        private bool IsPressingSpaceKey => Input.GetKey(KeyCode.Space);
        
        private void Update()
        {
            if (IsPressingSpaceKey)
            {
                _rigidbody.AddForce(_settings.JumpForce, ForceMode.Impulse);
            }
        }
    }
}