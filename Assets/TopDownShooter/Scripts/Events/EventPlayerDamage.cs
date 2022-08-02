using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter.Events
{
    public struct EventPlayerDamage
    {
        public float Damage { get; }
        public PlayerStat ReceiverStat;
        public PlayerStat ShooterStat;

        public EventPlayerDamage(float damage, PlayerStat receiver, PlayerStat shooter)
        {
            Damage = damage;
            ReceiverStat = receiver;
            ShooterStat = shooter;
        }
    }
}