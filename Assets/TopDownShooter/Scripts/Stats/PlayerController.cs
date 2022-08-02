using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Network;
using TopDownShooter.Stats;
using UniRx;
using UnityEngine;
using NetworkPlayer = TopDownShooter.Network.NetworkPlayer;

namespace TopDownShooter
{
    public class PlayerController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private DamageableObjectBase[] damageableObjectBases;
        [SerializeField] protected PlayerInventoryController playerInventoryController;
        [SerializeField] private NetworkPlayer networkPlayer;

        public PlayerStat PlayerStat { get; set; }
        
        protected void Start()
        {
            networkPlayer.RegisterStatHolder(playerInventoryController);
            networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);

            for (int i = 0; i < damageableObjectBases.Length; i++)
            {
                networkPlayer.RegisterStatHolder(damageableObjectBases[i]);
            }
            
            networkPlayer.RegisterStatHolder(this);
        }

        private void OnDeath(Unit obj)
        {
            if (networkPlayer.PlayerStat.IsLocalPlayer)
            {
                MatchmakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetStat(PlayerStat playerStat)
        {
            PlayerStat = playerStat;
            playerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
        }
    }
}