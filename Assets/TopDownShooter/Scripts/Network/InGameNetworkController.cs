using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Events;
using TopDownShooter.Inventory;
using TopDownShooter.Stats;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Network
{
    public enum InGameNetworkState { NotReady, Ready }
    
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer localPlayer;
        [SerializeField] private NetworkPlayer remotePlayer;
        private InGameNetworkState inGameNetworkState;
        
        private void Awake()
        {
            MessageBroker.Default.Receive<EventSceneLoaded>().Subscribe(OnSceneLoaded).AddTo(gameObject);
            MessageBroker.Default.Receive<EventPlayerShoot>().Subscribe(OnPlayerShoot).AddTo(gameObject);
            MessageBroker.Default.Receive<EventPlayerDamage>().Subscribe(OnPlayerDamage).AddTo(gameObject);
        }
        
        private void OnSceneLoaded(EventSceneLoaded eventScene)
        {
            switch (eventScene.SceneName)
            {
                case "GameScene" :
                    inGameNetworkState = InGameNetworkState.Ready;
                    PhotonNetwork.isMessageQueueRunning = true;
                    InstansiatePlayer();
                    break;
                default:
                    inGameNetworkState = InGameNetworkState.NotReady;
                    break;
            }
        }
        
        private void OnPlayerShoot(EventPlayerShoot playerShoot)
        {
            if (playerShoot.PlayerStat.IsLocalPlayer)
            {
                Shoot(playerShoot.Origin);     
            }
        }

        private void OnPlayerDamage(EventPlayerDamage eventPlayerDamage)
        {
            if (eventPlayerDamage.ShooterStat.IsLocalPlayer)
            {
                Damage(eventPlayerDamage.Damage, eventPlayerDamage.ReceiverStat.Id, eventPlayerDamage.ShooterStat.Id);
            }
        }
        
        public void InstansiatePlayer()
        {
            int[] allocatedViewIDArray = new int[localPlayer.PhotonViewsForOwnership.Length];
            for (int i = 0; i < allocatedViewIDArray.Length; i++)
            {
                allocatedViewIDArray[i] = PhotonNetwork.AllocateViewID();
            }

            photonView.RPC(nameof(RPC_InstansiatedPlayer), PhotonTargets.AllViaServer ,allocatedViewIDArray);
        }
        
        [PunRPC]
        public void RPC_InstansiatedPlayer(int[] viewIDArray, PhotonMessageInfo photonNetworkingMessage)
        {
            var instanisated = Instantiate( photonNetworkingMessage.sender.IsLocal ? localPlayer : remotePlayer);
            instanisated.SetOwnership(photonNetworkingMessage.sender, viewIDArray);
        }
        
        public void Shoot(Vector3 origin)
        {
            photonView.RPC(nameof(RPC_Shoot), PhotonTargets.Others, origin);
        }

        [PunRPC]
        public void RPC_Shoot(Vector3 origin,PhotonMessageInfo photonNetworkingMessage)
        {
            MessageBroker.Default.Publish(new EventPlayerShoot(origin, 
                ScriptableStatManager.Instance.Find(photonNetworkingMessage.sender.ID)));
        }

        public void Damage(float damage, int receiverID, int shooterID)
        {
            photonView.RPC(nameof(RPC_Damage),PhotonTargets.Others, damage, receiverID, shooterID);
        }

        [PunRPC]
        public void RPC_Damage(float damage, int receiverID, int shooterID)
        {
            var receiverStat = ScriptableStatManager.Instance.Find(receiverID);
            var shooterStat = ScriptableStatManager.Instance.Find(shooterID);
            receiverStat.Damage(damage, shooterStat);
        }
    }
}