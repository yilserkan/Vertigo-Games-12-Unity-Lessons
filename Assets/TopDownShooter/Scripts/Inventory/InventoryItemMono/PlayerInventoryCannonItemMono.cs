using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCannonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform cannonShotPoint;

        public void Shoot(IDamage damage)
        {
            ScriptableShootManager.Instance.Shoot(cannonShotPoint.position, cannonShotPoint.forward, damage);
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
