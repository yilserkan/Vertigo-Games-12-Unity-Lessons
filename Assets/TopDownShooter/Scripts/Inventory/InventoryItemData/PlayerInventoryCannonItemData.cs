using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Cannon Item Data")]
    public class PlayerInventoryCannonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>
    {
        public override void CreateIntoInventory(PlayerInventoryController playerInventoryController)
        {
            var prefab = InstansiateAndInitializePrefab(playerInventoryController.Parent);
            Debug.Log("Called from Cannon Item Data");
        }
    }

}
