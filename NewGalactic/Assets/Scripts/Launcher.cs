using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Launcher : Photon.PunBehaviour
{
	public GameObject hostGameButton;
	public GameObject joinGameButton;
	public GameObject hostRoomNameInput;
	public GameObject joinRoomNameInput;
    public GameObject loadingText;
    public GameObject joinError;
    public GameObject hostError;
    public GameObject errorButton;

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
        loadingText.SetActive(false);
        hostError.SetActive(false);
        joinError.SetActive(false);
        errorButton.SetActive(false);
	}
    #endregion

    #region Public Methods
	public void Connect() {
        isConnecting = true;
        ShowLoading();
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
	}

    public void ResetAfterError()
    {
        isConnecting = false;

        errorButton.SetActive(false);
        hostError.SetActive(false);
        joinError.SetActive(false);

        hostGameButton.SetActive(true);
        hostRoomNameInput.SetActive(false);
        joinGameButton.SetActive(true);
        joinRoomNameInput.SetActive(false);
    }
		
    public override void OnConnectedToMaster()
    {
        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");

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

    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        //PhotonNetwork.LoadLevel("CharacterSelection");
		((LevelManager)GameObject.FindObjectOfType<LevelManager>()).LoadScene("CharacterSelection");

    }

    public void OnPhotonJoinRoomFailed()
    {
        loadingText.SetActive(false);
        joinError.SetActive(true);
        errorButton.SetActive(true);
        PhotonNetwork.Disconnect();
    }

    public void OnPhotonCreateRoomFailed()
    {
        loadingText.SetActive(false);
        hostError.SetActive(true);
        errorButton.SetActive(true);
        PhotonNetwork.Disconnect();
    }
    #endregion

    private void OpenInputFields(bool host)
    {
        isHostPlayer = host;
        if (isHostPlayer)
        {
            hostGameButton.SetActive(false);
            hostRoomNameInput.SetActive(true);

            joinGameButton.SetActive(true);
            joinRoomNameInput.SetActive(false);

            GameObject.FindObjectOfType<CharManager>().isChar1 = true;
        }
        else
        {
            joinGameButton.SetActive(false);
            joinRoomNameInput.SetActive(true);

            hostGameButton.SetActive(true);
            hostRoomNameInput.SetActive(false);

            GameObject.FindObjectOfType<CharManager>().isChar1 = false;
        }
    }

    private void ShowLoading()
    {
        hostGameButton.SetActive(false);
        hostRoomNameInput.SetActive(false);
        joinGameButton.SetActive(false);
        joinRoomNameInput.SetActive(false);

        loadingText.SetActive(true);
    } 
}
