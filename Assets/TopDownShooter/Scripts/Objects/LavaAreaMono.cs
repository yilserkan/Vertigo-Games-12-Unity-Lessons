using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour, IDamage
    {
        [SerializeField] private float damage = 5;
        public float Damage { get { return damage; } }

        [Range(.1f, 2)]
        [SerializeField] private float armorPenetration = 1;
        public float ArmorPenetration { get { return armorPenetration; } }
        
        [SerializeField] private float timeBaseDamage = 5f;
        public float TimeBaseDamage { get { return timeBaseDamage; } }
        

        [SerializeField] private float timeBaseDamageDuration = 1f;
        public float TimeBaseDamageDuration { get { return timeBaseDamageDuration; } }
        public PlayerStat PlayerStat { get { return null; } }

        private void OnTriggerEnter(Collider collider)
        {
            int colliderInstanceID = collider.GetInstanceID();
            if (DamageableHelper.DamageablesList.ContainsKey(colliderInstanceID))
            {
                DamageableHelper.DamageablesList[colliderInstanceID].Damage(this);
            }
        }
    }
}
