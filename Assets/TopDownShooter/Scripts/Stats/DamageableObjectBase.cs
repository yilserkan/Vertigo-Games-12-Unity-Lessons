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
                
                Debug.Log($"Damage Amount -> {damage}, Remaining health -> {health}");

                if (health <= 0)
                {
                    this.RemoveDamageable();
                    OnDeath.Execute();
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
