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
     
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        private List<IPlayerStatHolder> _playerStatHolders = new List<IPlayerStatHolder>();
        public PhotonView[] PhotonViewsForOwnership { get { return _photonViewsForOwnership; } }

        private bool _instanstiated = false;
        public void SetOwnership(PhotonPlayer player, int[] viewIdArray)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = viewIdArray[i];
                _photonViewsForOwnership[i].TransferOwnership(player);
            }

            PlayerStat = new PlayerStat(player.ID, PhotonNetwork.player.IsLocal);

            for (int i = 0; i < _playerStatHolders.Count; i++)
            {
                _playerStatHolders[i].SetStat(PlayerStat);
            }

            _instanstiated = true;
        }

        public void RegisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolders.Add(playerStatHolder);
            if (_instanstiated)
            {
                playerStatHolder.SetStat(PlayerStat);
            }
        }
        
        public void UnregisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolders.Remove(playerStatHolder);
        }
    }
}