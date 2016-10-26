using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Photon.PunBehaviour {

	public void Start(){
		DontDestroyOnLoad (gameObject);
        PhotonNetwork.automaticallySyncScene = true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void ResetGame(){
		LoadScene ("MainMenu");

	}
	
}
