using UnityEngine;

namespace Assets.Scripts.Client
{
    public class ClientMode : MonoBehaviour
    {
        public GameObject player;
        
        private string ipServer = "192.168.15.2";
        private int portServer = 1421;

        public void setPlayer(GameObject player)
        {
            this.player = player;
        }

        public void startClient()
        {
            Network.Connect(ipServer, portServer);
        }

        public void stopClient()
        {
            Network.Disconnect(100);
        }

        public void spawnPlayer()
        {
            GameObject sPlayer = (GameObject)Network.Instantiate(player, player.transform.position, player.transform.rotation, 0);
        }
    }
}
