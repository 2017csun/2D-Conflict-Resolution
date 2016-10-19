using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Launcher : Photon.PunBehaviour
{
    /*
	[Tooltip("The Ui Panel to let the user enter name, connect and play")]
    public GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    public GameObject progressLabel;
	*/

	public GameObject hostGameButton;
	public GameObject joinGameButton;
	public GameObject hostRoomNameInput;
	public GameObject joinRoomNameInput;

    string _gameVersion = "1";
    PhotonLogLevel Loglevel = PhotonLogLevel.Full;
    bool isConnecting;
	bool isHostPlayer;


    #region MonoBehaviour CallBacks
    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        PhotonNetwork.logLevel = Loglevel;

        // #Critical
        // we don't join the lobby. There is no need to join a lobby to get the list of rooms.
        PhotonNetwork.autoJoinLobby = false;

        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.automaticallySyncScene = false;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
		hostRoomNameInput.SetActive(false);
		joinRoomNameInput.SetActive(false);
		/*
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
		*/
	}
    #endregion

    #region Public Methods
    /// <summary>
    /// Start the connection process. 
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
	///
	public void OpenInputFields(bool host) {
		isHostPlayer = host;
		if (isHostPlayer) {
			hostGameButton.SetActive (false);
			hostRoomNameInput.SetActive(true);
		} else {
			//hostGameButton.SetActive (false);
			joinGameButton.SetActive(false);
			joinRoomNameInput.SetActive(true);
		}
	}

	public void Connect() {
		// #Critical, we must first and foremost connect to Photon Online Server.
		//isHostPlayer = host;
		isConnecting = true;
		PhotonNetwork.ConnectUsingSettings(_gameVersion);
	}

	/*
    public void Connect()
    {
        // keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
        isConnecting = true;

        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        // we check if we are connected or not, we join if we are, else we initiate the connection to the server.
        if (PhotonNetwork.connected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }
    }
    */
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");

		/*
		if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnPhotonRandomJoinFailed()
			PhotonNetwork.JoinRandomRoom();
        }
		*/

		if (isConnecting)
		{
			if (isHostPlayer) {
				GameObject inputFieldGO = GameObject.Find("Canvas/Menu/HostGameNameInput");
				InputField inputField = inputFieldGO.GetComponent<InputField>();

				//Debug.Log("hostNameInput.text is" + hostRoomNameInput.text);
				PhotonNetwork.CreateRoom (inputField.text, new RoomOptions () { MaxPlayers = 2 }, null);
			} else {
				GameObject inputFieldGO = GameObject.Find("Canvas/Menu/JoinGameNameInput");
				InputField inputField = inputFieldGO.GetComponent<InputField>();

				PhotonNetwork.JoinRoom (inputField.text);
			}
		}

    }

    public override void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
        /*
		progressLabel.SetActive(false);
        controlPanel.SetActive(true);
		*/
	}

	/*
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 2}, null);");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom("roomname", new RoomOptions() { MaxPlayers = 2 }, null);
    }
    */

    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        PhotonNetwork.LoadLevel("Instructions");
    }

    #endregion

}
