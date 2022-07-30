using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stats
{
    public static class DamageableHelper
    {
        public static Dictionary<int, IDamageable> DamageablesList = new Dictionary<int, IDamageable>();

        public static void InitializeDamageable(this IDamageable damageable)
        {
            DamageablesList.Add(damageable.InstanceID, damageable);
        }

        public static void RemoveDamageable(this IDamageable damageable)
        {
            DamageablesList.Remove(damageable.InstanceID);
        }
    }
    
    public interface IDamageable
    {
        int InstanceID { get; }

        void Damage(IDamage damage);
    }
}