using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public struct EventPlayerShoot
    {
        public Vector3 Origin;
        public PlayerStat PlayerStat;

        public EventPlayerShoot(Vector3 origin, PlayerStat playerStat)
        {
            Origin = origin;
            PlayerStat = playerStat;
        }
    }
}
