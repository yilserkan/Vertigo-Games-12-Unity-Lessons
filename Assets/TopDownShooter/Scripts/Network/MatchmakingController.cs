using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{
    public enum PlayerNetworkState {None ,Offline, Connecting, Connected,JoiningRoom ,InRoom}
    
    public class MatchmakingController : Photon.PunBehaviour
    {
        public static MatchmakingController Instance;

        private string _networkVersion = "v1.0";

        private PlayerNetworkState _currentNetworkState = PlayerNetworkState.None;
        public PlayerNetworkState CurrentNetworkState
        {
            get
            {
                return _currentNetworkState;
            }
            set
            {
                bool sendEvent = _currentNetworkState != value;

                _currentNetworkState = value;
                if (sendEvent)
                {
                    MessageBroker.Default.Publish(new EventPlayerNetworkState(_currentNetworkState));
                }
            }
        }


        private void Awake()
        {
            Instance = this;
            PhotonNetwork.CacheSendMonoMessageTargets(typeof(MatchmakingController));
        }

        private IEnumerator Start()
        {
            CurrentNetworkState = PlayerNetworkState.Offline;

            yield return new WaitForEndOfFrame();
            
            CurrentNetworkState = PlayerNetworkState.Connecting;
            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void CreateRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.JoinRandomRoom();
        }
        
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            CurrentNetworkState = PlayerNetworkState.Connected;
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            CurrentNetworkState = PlayerNetworkState.InRoom;
            PhotonNetwork.isMessageQueueRunning = false;
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            CurrentNetworkState = PlayerNetworkState.Connected;
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            CurrentNetworkState = PlayerNetworkState.Offline;
        }
    }
}