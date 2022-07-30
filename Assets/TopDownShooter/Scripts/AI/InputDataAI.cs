using UnityEngine;
using TopDownShooter.PlayerInput;

namespace TopDownShooter.AI
{
    public class InputDataAI : AbstractInputData
    {
        protected Transform targetTransform;
        protected Transform aiTransform;
        public void SetTarget(Transform from ,Transform to)
        {
            aiTransform = from;
            this.targetTransform = to;
        }

        public override void ProcessInput()
        {
            
        }
    }
}

