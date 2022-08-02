using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Events;
using TopDownShooter.Inventory;
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
            if (PhotonNetwork.player.ID == playerShoot.PlayerID)
            {
                Shoot(playerShoot.Origin);     
            }
        }

        public void InstansiatePlayer()
        {
            var instansiated = Instantiate(localPlayer);
            int[] allocatedViewIDArray = new int[instansiated.PhotonViewsForOwnership.Length];
            for (int i = 0; i < allocatedViewIDArray.Length; i++)
            {
                allocatedViewIDArray[i] = PhotonNetwork.AllocateViewID();
            }
            instansiated.SetOwnership(PhotonNetwork.player, allocatedViewIDArray);
            
            photonView.RPC(nameof(RPC_InstansiatedPlayer), PhotonTargets.OthersBuffered ,allocatedViewIDArray);
        }
        
        [PunRPC]
        public void RPC_InstansiatedPlayer(int[] viewIDArray, PhotonMessageInfo photonNetworkingMessage)
        {
            var instanisated = Instantiate(remotePlayer);
            instanisated.SetOwnership(photonNetworkingMessage.sender, viewIDArray);
        }
        
        public void Shoot(Vector3 origin)
        {
            photonView.RPC(nameof(RPC_Shoot), PhotonTargets.Others, origin);
        }

        [PunRPC]
        public void RPC_Shoot(Vector3 origin,PhotonMessageInfo photonNetworkingMessage)
        {
            MessageBroker.Default.Publish(new EventPlayerShoot(origin,photonNetworkingMessage.sender.ID));
        }
    }
}