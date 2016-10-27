using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Launcher : Photon.PunBehaviour
{
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
        PhotonNetwork.automaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
		hostRoomNameInput.SetActive(false);
		joinRoomNameInput.SetActive(false);
	}
    #endregion

    #region Public Methods

	public void OpenInputFields(bool host) {
		isHostPlayer = host;
		if (isHostPlayer) {
			hostGameButton.SetActive (false);
			hostRoomNameInput.SetActive(true);
			GameObject.FindObjectOfType<CharManager> ().isChar1 = true;
		} else {
			//hostGameButton.SetActive (false);
			joinGameButton.SetActive(false);
			joinRoomNameInput.SetActive(true);
			GameObject.FindObjectOfType<CharManager> ().isChar1 = false;

		}
	}

	public void Connect() {
		// #Critical, we must first and foremost connect to Photon Online Server.
		//isHostPlayer = host;
		isConnecting = true;
		PhotonNetwork.ConnectUsingSettings(_gameVersion);
	}
		
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
        //PhotonNetwork.LoadLevel("CharacterSelection");
		((LevelManager)GameObject.FindObjectOfType<LevelManager>()).LoadScene("CharacterSelection");

    }

    #endregion

}
