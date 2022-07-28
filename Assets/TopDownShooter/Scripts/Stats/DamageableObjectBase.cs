using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private Collider collider;
        [SerializeField] private float health = 100f;
        public int InstanceID { get; private set; }

        private Vector3 _defaultScale;
        private void Awake()
        {
            InstanceID = collider.GetInstanceID();
            this.InitializeDamageable();
            _defaultScale = transform.localScale;
        }

        public void Damage(float damageAmount)
        {
            health -= damageAmount;
            Debug.Log($"Damage Amount -> {damageAmount}, Remaining health -> {health}");
            
            if (health <= 0)
            {
                this.RemoveDamageable();
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, (health/100f)*_defaultScale, 1);
        }
    }
}
