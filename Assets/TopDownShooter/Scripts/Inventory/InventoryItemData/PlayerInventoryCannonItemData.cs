using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/Cannon Item Data")]
    public class PlayerInventoryCannonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>, IDamage
    {
        [SerializeField] private float damage = 5;
        public float Damage { get { return damage; } }
        
        [SerializeField] private float rpm = 1;
        public float RPM { get { return rpm; } }
        
        public PlayerStat PlayerStat { get { return playerInventory.PlayerStat; } }

        [Range(.1f, 2)]
        [SerializeField] private float armorPenetration = 1;
        public float ArmorPenetration { get { return armorPenetration; } }
        
        
        [SerializeField] private float timeBaseDamage = 5f;
        public float TimeBaseDamage { get { return timeBaseDamage; } }
        

        [SerializeField] private float timeBaseDamageDuration = 1f;
        public float TimeBaseDamageDuration { get { return timeBaseDamageDuration; } }
        
        private float _lastShootTime;
        
        public override void InstansiateAndInitialize(PlayerInventoryController playerInventoryController)
        {
            base.InstansiateAndInitialize(playerInventoryController);
            InstansiateAndInitializePrefab(playerInventoryController.CannonParent);

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
                instansiated.Shoot(this, playerInventory.PlayerStat);
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.Log("Cant Shoot now");
            }

        }
        
    }

}
