using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Stats;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        public PlayerStat PlayerStat { get; private set; }
        public bool IsLocalPlayer { get; set; }
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        private List<IPlayerStatHolder> _playerStatHolders = new List<IPlayerStatHolder>();
        public PhotonView[] PhotonViewsForOwnership { get { return _photonViewsForOwnership; } }
        public void SetOwnership(PhotonPlayer player, int[] viewIdArray)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = viewIdArray[i];
                _photonViewsForOwnership[i].TransferOwnership(player);
            }

            PlayerStat = new PlayerStat(player.ID);
            IsLocalPlayer = PhotonNetwork.player.IsLocal;
        }

        public void RegisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolders.Add(playerStatHolder);
        }
        
        public void UnregisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolders.Remove(playerStatHolder);
        }
    }
}