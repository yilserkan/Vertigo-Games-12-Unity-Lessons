using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData inputData;
        private void Update()
        {
            inputData.Horizontal = Input.GetAxis("Horizontal");
            inputData.Vertical = Input.GetAxis("Vertical");
        }
    }

}
