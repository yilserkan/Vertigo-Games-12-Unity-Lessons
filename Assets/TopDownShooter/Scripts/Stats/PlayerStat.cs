using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Stats
{
    public class PlayerStat : IDamageable
    {
        public ReactiveProperty<float> Health = new ReactiveProperty<float>( 100f);
        public ReactiveProperty<float> Armor = new ReactiveProperty<float>( 100f);
        
        public ReactiveCommand OnDeath = new ReactiveCommand();
        private bool _isDead = false;
        public int Id { get; set; }
        public int InstanceID { get; } = -1;

        public PlayerStat(int id)
        {
            Id = id;
        }

     
        public void Damage(IDamage damage)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= damage.Damage * damage.ArmorPenetration;
            }
            else
            {
                Health.Value -= damage.Damage;

                // If Armor got more damage than its value substract it from damage
                Health.Value += Armor.Value;
                Armor.Value = 0;
                
                CheckHealth();
            }
        }
        
        public void Damage(float damage)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= damage * damage;
            }
            else
            {
                Health.Value -= damage;

                // If Armor got more damage than its value substract it from damage
                Health.Value += Armor.Value;
                Armor.Value = 0;
                
                CheckHealth();
            }
        }
        
        private void CheckHealth()
        {
            if (_isDead)
            {
                return;
            }
            if ( Health.Value <= 0)
            {
                this.RemoveDamageable();
                _isDead = true;
                OnDeath.Execute();
            }
        }
    }
}