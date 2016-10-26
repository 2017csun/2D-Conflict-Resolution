using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Photon.PunBehaviour
{

	public void Awake(){
		DontDestroyOnLoad (gameObject);
	}

    public void LoadScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

	public void ResetGame(){
		LoadScene ("MainMenu");

	}
	
}
