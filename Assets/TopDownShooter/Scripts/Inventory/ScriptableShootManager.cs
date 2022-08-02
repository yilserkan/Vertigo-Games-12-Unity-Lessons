using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/ScriptableShootManager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("Scriptbale Shoot Manager Initialized");
        }

        public override void Destroy()
        {
            base.Destroy();
            Debug.Log("Scriptable Shoot Manager Destroyed");
        }

        public void Shoot(Vector3 origin, Vector3 direction, IDamage damage, PlayerStat playerStat)
        {
            RaycastHit hit;
            
            MessageBroker.Default.Publish(new EventPlayerShoot(origin, playerStat));
            
            bool physics = Physics.Raycast(origin, direction, out hit);
            if (physics)
            {
                Debug.Log(hit.collider.name);
                
                int colliderInstanceID = hit.collider.GetInstanceID();
                if (DamageableHelper.DamageablesList.ContainsKey(colliderInstanceID))
                {
                    DamageableHelper.DamageablesList[colliderInstanceID].Damage(damage);
                }
            }
        }
    }

}
