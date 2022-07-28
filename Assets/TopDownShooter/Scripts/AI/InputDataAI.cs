using UnityEngine;
using TopDownShooter.PlayerInput;

public class InputDataAI : InputData
{
    protected Transform targetTransform;
    protected Transform aiTransform;
    public void SetTarget(Transform from ,Transform to)
    {
        aiTransform = from;
        this.targetTransform = to;
    }
}