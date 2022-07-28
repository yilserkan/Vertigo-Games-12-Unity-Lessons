using UnityEngine;
using TopDownShooter.PlayerInput;

public class InputDataAI : InputData
{
    protected Vector3 target;
    protected Transform aiTransform;
    public void SetTarget(Transform from ,Vector3 targetPosition)
    {
        aiTransform = from;
        target = targetPosition;
    }
}