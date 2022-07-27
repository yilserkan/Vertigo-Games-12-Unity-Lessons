using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public float Horizontal;
        public float Vertical;

        [Header("Basic Axis Input")]
        [SerializeField] private bool isAxisActive;
        [SerializeField] private string horizontalAxisName;
        [SerializeField] private string verticalAxisName;

        [Header("Basic Key Input")] 
        [SerializeField] private bool isHorizontalKeyInputActive;
        [SerializeField] private KeyCode horizontalPositiveKey;
        [SerializeField] private KeyCode horizontalNegativKey;
        
        [SerializeField] private bool isVerticalKeyInputActive;
        [SerializeField] private KeyCode verticalPositiveKey;
        [SerializeField] private KeyCode verticalNegativKey;
        [SerializeField] private float lerpSpeed = 1f;

        public void ProcessInput()
        {
            if (isAxisActive)
            {
                Horizontal = Input.GetAxis(horizontalAxisName);
                Vertical = Input.GetAxis(verticalAxisName);
            }
            else
            {
                if (isHorizontalKeyInputActive)
                {
                    ProcessKeyInput(ref Horizontal, horizontalPositiveKey, horizontalNegativKey);
                }
                else if(isVerticalKeyInputActive)
                {
                    ProcessKeyInput(ref Vertical, verticalPositiveKey, verticalNegativKey);
                }
            }
        }

        private void ProcessKeyInput(ref float value ,KeyCode positive, KeyCode negative)
        {
            bool positiveKeyPressed = Input.GetKey(positive);
            bool negativeKeyPressed = Input.GetKey(negative);

            if (positiveKeyPressed)
            {
                value = Mathf.Lerp(value, 1, lerpSpeed);
            }
            else if (negativeKeyPressed)
            {
                value = Mathf.Lerp(value, -1, lerpSpeed);
            }
            else
            {
                value = Mathf.Lerp(value, 0, lerpSpeed);
            }
        }
    }

}
