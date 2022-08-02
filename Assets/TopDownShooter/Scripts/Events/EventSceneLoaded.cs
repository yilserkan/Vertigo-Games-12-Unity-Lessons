using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Events
{
    public struct EventSceneLoaded
    {
        public string SceneName;

        public EventSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}

