using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Cannon Item Data")]
    public class PlayerInventoryCannonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>
    {
        [SerializeField] private float damage = 5;
        public float Damage { get { return damage; } }
        
        [SerializeField] private float rpm = 1;
        public float RPM { get { return rpm; } }

        private float _lastShootTime;
        
        public override void InstansiateAndInitialize(PlayerInventoryController playerInventoryController)
        {
            base.InstansiateAndInitialize(playerInventoryController);
            InstansiateAndInitializePrefab(playerInventoryController.Parent);

            playerInventoryController.ReactiveShootCommand.Subscribe(OnReactiveShootCommand).AddTo(compositeDisposable);
            
            Debug.Log("Called from Cannon Item Data");
        }

        private void OnReactiveShootCommand(Unit obj)
        {
            Debug.Log("On Reactive Shoot Command Executed");
            Shoot();
        }
        
        private void Shoot()
        {
            if (Time.time - _lastShootTime > rpm)
            {
                instansiated.Shoot();
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.Log("Cant Shoot now");
            }

        }
        
    }

}
