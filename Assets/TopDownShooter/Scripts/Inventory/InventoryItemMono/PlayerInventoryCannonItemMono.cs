using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCannonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform cannonShotPoint;

        public void Shoot()
        {
            ScriptableShootManager.Instance.Shoot(cannonShotPoint.position, cannonShotPoint.forward);
        }
    }

}
