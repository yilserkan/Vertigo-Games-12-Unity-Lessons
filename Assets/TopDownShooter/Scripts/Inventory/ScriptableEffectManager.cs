using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using UniRx;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Manager/ScriptableEffectManager")]
    public class ScriptableEffectManager : AbstractScriptableManager<ScriptableEffectManager>
    {
        [SerializeField] private GameObject shootEfect;
        
        public override void Initialize()
        {
            base.Initialize();
            MessageBroker.Default.Receive<EventPlayerShoot>().Subscribe(OnPlayerShoot).AddTo(compositeDisposable);
        }

        private void OnPlayerShoot(EventPlayerShoot eventPlayerShoot)
        {
            Instantiate(shootEfect, eventPlayerShoot.Origin, Quaternion.identity);
        }
        
    }

}
