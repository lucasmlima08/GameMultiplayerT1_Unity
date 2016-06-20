using UnityEngine;
using System.Collections;
using Assets.Scripts.Client;
using Assets.Scripts.Server;

public class Controller : MonoBehaviour {

    public GameObject playerObject;

    private ClientMode client = new ClientMode();
    private ServerMode server = new ServerMode();
            
    void Start () {

        if (Network.player.ipAddress.Equals("192.168.15.2"))
        {
            server.startServer();

			// Ativa a camera do servidor.
			GameObject camera = GameObject.Find("CameraServer");
			camera.SetActive(true);
        }
        else
        {
            client.startClient();

			// Desativa a camera do servidor.
			GameObject camera = GameObject.Find("CameraServer");
			camera.SetActive(false);
        }
	}
	
	void Update () {
	    
        if (Network.isClient)
        {
            //textAux.text = "É um cliente!";
        }

        else if (Network.isServer)
        {
            //textAux.text = "É um servidor!";
        }
	}

    /// <summary>
    /// Parte do Cliente.
    /// </summary>

    /// Chamado no cliente quando você se conectou com sucesso a um servidor.
    void OnConnectedToServer()
    {
        client.setPlayer(playerObject);
        client.spawnPlayer();
    }
    /// Chamado no cliente durante a desconexão do servidor, mas também no servidor quando a conexão foi desconectado.
    void OnDisconnectedFromServer()
    {
        ///
    }

    /// Chamado no cliente quando uma tentativa de conexão falhar por algum motivo.
    void OnFailedToConnect()
    {
        ///
    }

    /// Chamado em objetos que tenham sido rede instanciado com Network.Instantiate.
    //void OnNetworkInstantiate()
    //{
        ///
    //}

    /// <summary>
    /// Parte do Servidor.
    /// </summary>

    /// Chamado no servidor sempre que um Network.InitializeServer foi chamado e foi concluída.
    void OnServerInitialized()
    {

    }
    
    /// Chamado no servidor sempre que um novo jogador se conectou com sucesso.
    void OnPlayerConnected()
    {
        ///
    }

    /// Chamado no servidor sempre que um jogador é desconectado do servidor.
    void OnPlayerDisconnected()
    {
        ///
    }

    /// <summary>
    /// Métodos.
    /// </summary>

    //[RPC]
    //public void movementPlayer(float mX, float mZ)
    //{
		///
    //}
}
