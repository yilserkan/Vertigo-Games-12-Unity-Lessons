using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField] private AbstractScriptableManagerBase[] abstractScriptableManagerArray;
        [SerializeField] private bool _dontDestroyOnLoad;
        private List<AbstractScriptableManagerBase> _instansiatedScriptableManagerList;
       

        private void Start()
        {
            ClearManagers();

            _instansiatedScriptableManagerList =
                new List<AbstractScriptableManagerBase>(abstractScriptableManagerArray.Length);
            
            for (int i = 0; i < abstractScriptableManagerArray.Length; i++)
            {
                var instansiated = Instantiate(abstractScriptableManagerArray[i]);
                instansiated.Initialize();
                _instansiatedScriptableManagerList.Add(instansiated);
            }

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            ClearManagers();
        }

        private void ClearManagers()
        {
            if (_instansiatedScriptableManagerList != null)
            {
                for (int i = 0; i < _instansiatedScriptableManagerList.Count; i++)
                {
                    _instansiatedScriptableManagerList[i].Destroy();
                }
            }
        }
    }

}
