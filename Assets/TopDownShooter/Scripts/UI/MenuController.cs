using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TopDownShooter.Network;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI connectionState;
        [SerializeField] private Button[] buttons;
        private void Awake()
        {
            MessageBroker.Default.Receive<EventPlayerNetworkState>().Subscribe(OnPlayerNetworkStateChange);
        }

        private void OnPlayerNetworkStateChange(EventPlayerNetworkState obj)
        {
            Debug.Log("Netowke state change to" + obj._playerNetworkState);
            connectionState.text = obj._playerNetworkState.ToString();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = obj._playerNetworkState == PlayerNetworkState.Connected;
            }
        }

        public void _CreateRoom()
        {
            MatchmakingController.Instance.CreateRoom();
        }
        
        public void _JoinRandomRoom()
        {
            MatchmakingController.Instance.JoinRandomRoom();
        }
        public void _Settings()
        {
            Debug.LogError("not working yet");
        }
    }
}