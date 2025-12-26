using UnityEngine;
using Mirror;
using KadenZombie8.Pooling;

namespace KadenZombie8.BIMOS.Networking
{
    public class NetManager : NetworkManager
    {
        public static new NetManager singleton;
        [Header("BIMOS Settings")]
        public PoolConfig rigsPoolConfig;

        public override void Awake() {
            base.Awake();
            singleton = this;
        }

        public void HostGame(int maxClients = 10, bool serverOnly = false) {
            maxConnections = maxClients;
            if(serverOnly) StartServer();
            else StartHost();
        }

        public void JoinGame(string address) {
            networkAddress = address;
            StartClient();
        }
    }
}
