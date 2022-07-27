using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public enum PlayerInventoryItemTypes{ Cannon, Body }
    
    public abstract class AbstractPlayerInventoryItemData<T> : AbstractBasePlayerInventoryItemData 
                                                                where T: AbstractPlayerInventoryItemMono
    {
        [SerializeField] protected string itemId;
        [SerializeField] protected PlayerInventoryItemTypes itemType;
        [SerializeField] protected T prefab;

        protected T InstansiateAndInitializePrefab(Transform parent)
        {
            return Instantiate(prefab, parent);
        }
        
    }

}
