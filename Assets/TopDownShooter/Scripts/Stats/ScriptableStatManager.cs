using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stats
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Manager/ScriptableStatManager")]
    public class ScriptableStatManager : AbstractScriptableManager<ScriptableStatManager>
    {
        private List<PlayerStat> _playerStats = new List<PlayerStat>();

        public void RegisterPlayerStat(PlayerStat playerStat)
        {
            _playerStats.Add(playerStat);
        }

        public PlayerStat Find(int id)
        {
            for (int i = 0; i < _playerStats.Count; i++)
            {
                if (_playerStats[i].Id == id)
                {
                    return _playerStats[i];
                }
            }
            throw new System.Exception("Couldn't find player with id " + id);
        }
    }
}