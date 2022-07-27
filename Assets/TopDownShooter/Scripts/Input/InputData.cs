using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        [SerializeField] private float horizontal;
        [SerializeField] private float vertical;

        public float Horizontal { get { return horizontal; } set { horizontal = value; } }
        public float Vertical { get { return vertical; } set { vertical = value; } }
    }

}
