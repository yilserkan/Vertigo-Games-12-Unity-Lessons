using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input/TCK Input Data")]
    public class TCKInputData : AbstractInputData
    {
        [Header("Axis")]
        [SerializeField] private string axisName;
        
        [Header("Action")]
        [SerializeField] private string actionName;
        [SerializeField] private bool isAction;
        
        public override void ProcessInput()
        {
            if (isAction)
            {
                if (TCKInput.GetAction(actionName, EActionEvent.Down))
                {
                    Horizontal = 1;
                }
                else if (TCKInput.GetAction(actionName, EActionEvent.Up))
                {
                    Horizontal = 0;
                }
            }
            else
            {
                Vector2 movement = TCKInput.GetAxis(axisName);
                Horizontal = movement.x;
                Vertical = movement.y;
            }
        }
    }

}
