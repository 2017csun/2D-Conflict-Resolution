using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Photon.PunBehaviour {

	public void Start(){
		DontDestroyOnLoad (this.gameObject);
        PhotonNetwork.automaticallySyncScene = true;
    }

    public void LoadScene(string sceneName)
    {
        this.photonView.RPC("LoadSceneRPC", PhotonTargets.MasterClient, sceneName);
    }



	public void ResetGame(){
		LoadScene ("MainMenu");

	}

    [PunRPC]
    void LoadSceneRPC(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
