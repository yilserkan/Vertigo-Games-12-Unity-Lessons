using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stats
{
    public interface IDamage
    {
        float Damage { get; }
        float ArmorPenetration { get; }
        float TimeBaseDamage { get; }
        float TimeBaseDamageDuration { get; }
        
        PlayerStat PlayerStat { get; }
    }
}

