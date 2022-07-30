using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private AbstractInputData[] inputData;
        private void Update()
        {
            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i].ProcessInput();
            }
        }
    }

}
