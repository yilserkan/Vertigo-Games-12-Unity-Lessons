using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Input/AI/AI Rotation Input Data")]
    public class InputRotationDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            Vector3 tempTarget = new Vector3(targetTransform.position.x, 0, targetTransform.position.z);
            Vector3 tempAiPosition = new Vector3(aiTransform.position.x, 0, aiTransform.position.z);
            
            float dotTurnRotation = Vector3.Dot(aiTransform.right, (tempTarget - tempAiPosition).normalized);

            float signOfDotProduct = Mathf.Sign(dotTurnRotation);
            
            // This dot product checks if the target is in front or back of the AI.
            // Becaasue the value of dotTurnRotation will be 0 if the target is directly in front or behind the AI
            // So we need to check if the target is infront only then it shoudl stop turning
            float dotTargetInFront = Vector3.Dot(aiTransform.forward, (tempTarget - tempAiPosition).normalized);

            if (Mathf.Abs(dotTurnRotation) > .01f || dotTargetInFront < .99f)
            {
                Horizontal = signOfDotProduct > 0 ? 1 : -1;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}
