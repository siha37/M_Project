using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;

namespace MyFolder._01._Script._1002.TestScript
{
    public class EnemySpawn : NetworkBehaviour
    {
        [SerializeField] private GameObject spawnPrefab;
        NetworkConnection hostConnection;

        public override void OnStartClient()
        {
            hostConnection = ClientManager.Connection;
            GameObject enemy = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
            InstanceFinder.ServerManager.Spawn(enemy,hostConnection);
        }
    }
}
