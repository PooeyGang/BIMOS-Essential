using UnityEngine;
using UnityEngine.Events;
using Riptide;
using System;
using Riptide.Utils;
namespace KadenZombie8.BIMOS.Networking {
    [DefaultExecutionOrder(-1500)]
    public class NetworkManager : MonoBehaviour {
        private static NetworkManager _singleton;
        public static NetworkManager Singleton {
            get => _singleton;
            private set {
                if (_singleton == null)
                    _singleton = value;
                else if (_singleton != value) {
                    Debug.Log($"{nameof(NetworkManager)} instance already exists, destroying object!");
                    Destroy(value);
                }
            }
        }

        public ushort Port = 7777;
        public ushort MaxPlayers = 10;

        public Server Server {
            get; private set;
        }
        public Client Client {
            get; private set;
        }

        private void Awake() {
            Singleton = this;
        }

        private void Start() {
            RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);

            Server = new Server();
            Server.ClientConnected += PlayerJoined;

            Client = new Client();
            Client.Connected += DidConnect;
            Client.ConnectionFailed += FailedToConnect;
            Client.ClientDisconnected += PlayerLeft;
            Client.Disconnected += DidDisconnect;
        }

        private void FixedUpdate() {
            if (Server.IsRunning)
                Server.Update();

            Client.Update();
        }

        private void OnApplicationQuit() {
            Server.Stop();
            Client.Disconnect();
        }

        public bool StartServer(bool asHost) {
            StartServer();
            if(asHost) return true;
            return JoinGame("127.0.0.1");
        }

        public void StartServer() {
            Server.Start(Port, MaxPlayers);
            onStartServer?.Invoke();
        }

        public bool JoinGame(string ipString) {
            bool connected = Client.Connect($"{ipString}:{Port}");
            if (!connected)
                connected = Client.Connect($"127.0.0.1");
            return connected;
        }

        public void LeaveGame() {
            if (Server.IsRunning) {
                Server.Stop();
                onStopServer?.Invoke();
            }
            Client.Disconnect();
        }

        private void DidConnect(object sender, EventArgs e) {
            onStartClient?.Invoke();
        }

        private void FailedToConnect(object sender, EventArgs e) {
        }

        private void PlayerJoined(object sender, ServerConnectedEventArgs e) {
            foreach (var player in NetworkRig.Rigs.Values)
                if (player.Id != e.Client.Id)
                    player.SendSpawn(e.Client.Id);
        }

        private void PlayerLeft(object sender, ClientDisconnectedEventArgs e) {
            Destroy(NetworkRig.Rigs[e.Id].gameObject);
        }

        private void DidDisconnect(object sender, DisconnectedEventArgs e) {
            onStopClient?.Invoke();
            foreach (NetworkRig player in NetworkRig.Rigs.Values)
                Destroy(player.gameObject);
        }
        public UnityEvent onStartServer, onStopServer, onStartClient, onStopClient;
    }
        
}
