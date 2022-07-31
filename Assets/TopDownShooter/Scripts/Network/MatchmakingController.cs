using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{
    public enum PlayerNetworkState {Disconnected, Connecting, Connected,JoiningRoom ,InRoom}
    
    public class MatchmakingController : Photon.PunBehaviour
    {
        public static MatchmakingController Instance;

        private string _networkVersion = "v1.0";
        
        private void Awake()
        {
            Instance = this;
        }

        private IEnumerator Start()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.Disconnected));

            yield return new WaitForSeconds(3f);
            
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void CreateRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.JoinRandomRoom();
        }
        
        
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.Connected));
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkState(PlayerNetworkState.InRoom));
        }
    }
}