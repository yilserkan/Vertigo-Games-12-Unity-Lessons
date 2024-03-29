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
        [SerializeField] private TMP_InputField nameInputField;
        private void Awake()
        {
            UpdateUINetworkState(MatchmakingController.Instance.CurrentNetworkState);
            MessageBroker.Default.Receive<EventPlayerNetworkState>().Subscribe(OnPlayerNetworkStateChange);
            nameInputField.onEndEdit.AddListener(OnEndEdit);
        }

        private void OnEndEdit(string arg0)
        {
            PhotonNetwork.player.NickName = nameInputField.text;
        }
        
        private void OnPlayerNetworkStateChange(EventPlayerNetworkState obj)
        {
            Debug.Log("Netowke state change to" + obj._playerNetworkState);
            PlayerNetworkState playerNetworkState = obj._playerNetworkState;
            UpdateUINetworkState(playerNetworkState);
        }

        private void UpdateUINetworkState(PlayerNetworkState playerNetworkState)
        {
            connectionState.text = playerNetworkState.ToString();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = playerNetworkState == PlayerNetworkState.Connected;
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