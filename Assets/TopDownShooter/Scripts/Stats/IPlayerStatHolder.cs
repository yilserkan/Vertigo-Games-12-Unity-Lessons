using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stats
{
    public interface IPlayerStatHolder
    {
        PlayerStat PlayerStat { get; }

        void SetStat(PlayerStat playerStat);
    }
}