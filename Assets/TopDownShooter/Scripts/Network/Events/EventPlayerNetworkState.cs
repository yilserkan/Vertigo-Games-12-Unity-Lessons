using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public struct EventPlayerNetworkState
    {
        public PlayerNetworkState _playerNetworkState;

        public EventPlayerNetworkState(PlayerNetworkState playerNetworkState)
        {
            _playerNetworkState = playerNetworkState;
        }
        
    }
}
