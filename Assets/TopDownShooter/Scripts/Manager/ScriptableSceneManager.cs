using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Events;
using TopDownShooter.Network;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Manager/ScriptableSceneManager")]
    public class ScriptableSceneManager : AbstractScriptableManager<ScriptableSceneManager>
    {
        [SerializeField] private string gameScene;
        [SerializeField] private string menuScene;

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.LoadScene(menuScene);
            MessageBroker.Default.Receive<EventPlayerNetworkState>().Subscribe(OnEventPlayerNetworkState)
                .AddTo(compositeDisposable);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            MessageBroker.Default.Publish(new EventSceneLoaded(arg0.name));
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnEventPlayerNetworkState(EventPlayerNetworkState playerNetworkState)
        {
            switch (playerNetworkState._playerNetworkState)
            {
                case PlayerNetworkState.Offline:
                    break;
                case PlayerNetworkState.Connecting:
                    break;
                case PlayerNetworkState.Connected:
                    break;
                case PlayerNetworkState.JoiningRoom:
                    break;
                case PlayerNetworkState.InRoom:
                    SceneManager.LoadScene(gameScene);
                    break;
                default:
                    break;
            }
        }
    }

}
