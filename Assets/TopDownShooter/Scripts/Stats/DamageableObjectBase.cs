using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;
using UniRx;

namespace TopDownShooter
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable, IPlayerStatHolder
    {
        [SerializeField] private Collider collider;
        public PlayerStat PlayerStat { get; private set; }
        public int InstanceID { get; private set; }

        private Vector3 _defaultScale;
        private void Awake()
        {
            InstanceID = collider.GetInstanceID();
            this.InitializeDamageable();
            _defaultScale = transform.localScale;
        }

        public void Damage(IDamage damage)
        {
            if (damage.TimeBaseDamage > 0)
            {
                StartCoroutine(DealDamageOverTime(damage.TimeBaseDamage, damage.TimeBaseDamageDuration, damage.PlayerStat));
            }
            else
            {
                PlayerStat.Damage(damage);
            }
        
        }

     

        IEnumerator DealDamageOverTime(float damageAmount, float duration ,PlayerStat playerStat)
        {
            while (duration > 0)
            {
                yield return new WaitForSeconds(1);
                duration--;
                PlayerStat.Damage(damageAmount ,playerStat);
             
            }
        }

      
        public void SetStat(PlayerStat playerStat)
        {
            PlayerStat = playerStat;
        }
    }
}
