using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Input/AI/AI Movement Input Data")]
public class InputMovementDataAI : InputDataAI
{
    public override void ProcessInput()
    {
        float distanceToTarget = Vector3.Distance(target, aiTransform.position);

        if (distanceToTarget > 1f)
        {
            Vertical = 1;
        }
        else
        {
            Vertical = 0;
        }

        float dotTurnRotation = Vector3.Dot(aiTransform.right, (target - aiTransform.position).normalized);
        
        // This dot product checks if the target is in front or back of the AI.
        // Becaasue the value of dotTurnRotation will be 0 if the target is directly in front or behind the AI
        // So we need to check if the target is infront only then it shoudl stop turning
        float dotTargetInFront = Vector3.Dot(aiTransform.forward, (target - aiTransform.position).normalized);
        
        float signOfDotProduct = Mathf.Sign(dotTurnRotation);

        if (Mathf.Abs(dotTurnRotation) > .1f || dotTargetInFront < .9f)
        {
            Horizontal = signOfDotProduct > 0 ? 1 : -1;
        }
        else
        {
            Horizontal = 0;
        }
    }
    
}
