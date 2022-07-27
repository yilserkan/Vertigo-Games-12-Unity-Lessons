using System.Collections;
using System.Collections.Generic;
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

        public void Shoot()
        {
            
        }
    }

}
