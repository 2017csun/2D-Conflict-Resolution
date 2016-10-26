﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void Awake(){
		DontDestroyOnLoad (gameObject);
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void ResetGame(){
		SceneManager.LoadScene ("MainMenu");
        //TODO: more logic here when multiple players are involved. 
        // prompt user to confirm, then if they decide to exit, alert the other player.
	}
	
}
