using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;
using UniRx;

namespace TopDownShooter
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private Collider collider;
        [SerializeField] private float health = 100f;
        [SerializeField] private float armor = 100f;

        public ReactiveCommand OnDeath = new ReactiveCommand();

        private bool _isDead = false;
        
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
                StartCoroutine(DealDamageOverTime(damage.TimeBaseDamage, damage.TimeBaseDamageDuration));
            }
            
            if (armor > 0)
            {
                armor -= damage.Damage * damage.ArmorPenetration;
            }
            else
            {
                health -= damage.Damage;

                // If Armor got more damage than its value substract it from damage
                health += armor;
                armor = 0;
                
                CheckHealth();
            }
        }

        private void CheckHealth()
        {
            if (_isDead)
            {
                return;
            }
            if (health <= 0)
            {
                StopAllCoroutines();
                this.RemoveDamageable();
                _isDead = true;
                OnDeath.Execute();
                Destroy(gameObject);
            }
        }

        IEnumerator DealDamageOverTime(float damageAmount, float duration)
        {
            while (duration > 0)
            {
                yield return new WaitForSeconds(1);
                health -= damageAmount;
                duration--;
                
                CheckHealth();
            }
        }
        
    }
}
