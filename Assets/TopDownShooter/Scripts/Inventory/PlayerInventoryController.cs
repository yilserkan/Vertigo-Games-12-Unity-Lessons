using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] inventoryItemDataArray;
        private List<AbstractBasePlayerInventoryItemData> _instansiatedItemDataList;

        public Transform Parent;

        private void Start()
        {
            InitializeInventory();
        }

        private void OnDestroy()
        {
            ClearInventory();
        }

        private void InitializeInventory()
        {
            ClearInventory();

            _instansiatedItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                var instansiated = Instantiate(inventoryItemDataArray[i]);
                instansiated.CreateIntoInventory(this);
                _instansiatedItemDataList.Add(instansiated);
            }
        }

        private void ClearInventory()
        {
            if (_instansiatedItemDataList != null)
            {
                for (int i = 0; i < _instansiatedItemDataList.Count; i++)
                {
                    _instansiatedItemDataList[i].Destroy();
                }
            }
        }
    }
}

