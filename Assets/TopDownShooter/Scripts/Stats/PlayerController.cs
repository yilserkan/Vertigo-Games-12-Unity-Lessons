using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Network;
using UniRx;
using UnityEngine;
using NetworkPlayer = TopDownShooter.Network.NetworkPlayer;

namespace TopDownShooter
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private DamageableObjectBase[] damageableObjectBases;
        [SerializeField] protected PlayerInventoryController playerInventoryController;
        [SerializeField] private NetworkPlayer networkPlayer;

        protected void Start()
        {
            networkPlayer.RegisterStatHolder(playerInventoryController);
            networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);

            for (int i = 0; i < damageableObjectBases.Length; i++)
            {
                networkPlayer.RegisterStatHolder(damageableObjectBases[i]);
            }
        }

        private void OnDeath(Unit obj)
        {
            if (networkPlayer.IsLocalPlayer)
            {
                MatchmakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}