using UnityEngine;

namespace Assets.Scripts.Server
{
    public class ServerMode : MonoBehaviour
    {
        private int portServer = 1421;

        private NetworkPlayer networkPlayer;
        
        public void startServer()
        {
            Network.InitializeServer(10, portServer, false);
        }
        
        public void stopServer()
        {
            Network.Disconnect(100);
        }
    }
}
