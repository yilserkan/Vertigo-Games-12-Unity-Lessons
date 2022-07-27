using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Body Item Data")]
    public class PlayerInventoryBodyItemData : AbstractPlayerInventoryItemData<PlayerInventoryBodyItemMono>
    {
        public override void CreateIntoInventory(PlayerInventoryController playerInventoryController)
        {
            var prefab = InstansiateAndInitializePrefab(playerInventoryController.transform);
            Debug.Log("Called from Body Item Data");
        }
    }

}
