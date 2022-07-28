using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCannonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform cannonShotPoint;

        public void Shoot(float damageAmount)
        {
            ScriptableShootManager.Instance.Shoot(cannonShotPoint.position, cannonShotPoint.forward, damageAmount);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(cannonShotPoint.position, 0.15f);
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cannonShotPoint.position, cannonShotPoint.position + (cannonShotPoint.forward * 10));
        }
    }

}
