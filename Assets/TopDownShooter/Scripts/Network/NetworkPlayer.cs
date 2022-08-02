using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        public PhotonView[] PhotonViewsForOwnership { get { return _photonViewsForOwnership; } }
        public void SetOwnership(PhotonPlayer player, int[] viewIdArray)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = viewIdArray[i];
                _photonViewsForOwnership[i].TransferOwnership(player);
            }
        }
    }
}