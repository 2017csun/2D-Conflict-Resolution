using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Photon.PunBehaviour
{
    [Tooltip("The prefab to use for representing the player")]
    public GameObject playerPrefab;
	public GameObject camPrefab;


    void Start()
    {
        PhotonNetwork.automaticallySyncScene = true;

        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red>Missing</a> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            if (PlayerControl.LocalPlayerInstance == null)
		//	if(PhotonNetwork.player == null)
            {
                Debug.Log("We are Instantiating LocalPlayer from " + SceneManager.GetActiveScene().name);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-6f, 3f, 0f), Quaternion.identity, 0);
				if (playerPrefab.GetComponent<PlayerControl> () != null) {
					GameObject camera = Instantiate (camPrefab) as GameObject;
					camera.transform.position = Vector2.zero;
					Transform sdn = camera.transform;
					Debug.Log ("CAMERA TRANSFORM IS " + sdn);
					if (camera != null) {
						GameObject.FindObjectOfType<CameraWork> ().cameraTransform = camera.transform;
					}
				}
            }
            else
            {
                Debug.Log("Ignoring scene load for " + SceneManager.GetActiveScene().name);
            }
        }
    }

    #region Photon Messages
    public override void OnPhotonPlayerConnected(PhotonPlayer other)
    {
        Debug.Log("OnPhotonPlayerConnected() " + other.name); // not seen if you're the player connecting

        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected
            //LoadArena();
        }
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
    {
        Debug.Log("OnPhotonPlayerDisconnected() " + other.name); // seen when other disconnects

        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

            //LoadArena();
        }
    }

    /*
    void LoadArena()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        else
        {
            Debug.Log("PhotonNetwork : Loading Level");
            PhotonNetwork.LoadLevel("Level");
        }
    }
    */

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    #endregion


    #region Public Methods
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    #endregion
}
