using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Body Item Data")]
    public class PlayerInventoryBodyItemData : AbstractPlayerInventoryItemData<PlayerInventoryBodyItemMono>
    {
        public override void InstansiateAndInitialize(PlayerInventoryController playerInventoryController)
        {
            var prefab = InstansiateAndInitializePrefab(playerInventoryController.BodyParent);
            Debug.Log("Called from Body Item Data");
        }
    }

}
