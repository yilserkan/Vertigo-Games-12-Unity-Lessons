using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer localPlayer;
        [SerializeField] private NetworkPlayer remotePlayer;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);
            InstansiatePlayer();
        }
        
        public void InstansiatePlayer()
        {
            var instansiated = Instantiate(localPlayer);
            int viewID = PhotonNetwork.AllocateViewID();
            instansiated.photonView.viewID = viewID;
            instansiated.SetOwnership(PhotonNetwork.player);
            
            photonView.RPC(nameof(RPC_InstansiatedPlayer), PhotonTargets.OthersBuffered ,viewID);
        }
        
        [PunRPC]
        public void RPC_InstansiatedPlayer(int viewID, PhotonMessageInfo photonNetworkingMessage)
        {
            var instanisated = Instantiate(remotePlayer);
            instanisated.photonView.viewID = viewID;
            instanisated.SetOwnership(photonNetworkingMessage.sender);
        }
    }
}