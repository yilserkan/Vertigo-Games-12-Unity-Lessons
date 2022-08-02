using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] inventoryItemDataArray;
        private List<AbstractBasePlayerInventoryItemData> _instansiatedItemDataList;

        public ReactiveCommand ReactiveShootCommand;

        public Transform CannonParent;
        public Transform BodyParent;

        public int PlayerID { get; set; }
        public PlayerStat PlayerStat { get; private set; }

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
            if (ReactiveShootCommand != null)
            {
                ReactiveShootCommand.Dispose();
            }
            ReactiveShootCommand = new ReactiveCommand();
            
            ClearInventory();

            _instansiatedItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                var instansiated = Instantiate(inventoryItemDataArray[i]);
                instansiated.InstansiateAndInitialize(this);
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
        
        public void SetStat(PlayerStat playerStat)
        {
            PlayerStat = playerStat;
        }
    }
}

