using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        protected PlayerInventoryController playerInventory;
        protected CompositeDisposable compositeDisposable;

        public virtual void InstansiateAndInitialize(PlayerInventoryController targetPlayerInventory)
        {
            playerInventory = targetPlayerInventory;
            compositeDisposable = new CompositeDisposable();
        }

        public void Destroy()
        {
            compositeDisposable.Dispose();
            Destroy(this);
        }
    }

}
