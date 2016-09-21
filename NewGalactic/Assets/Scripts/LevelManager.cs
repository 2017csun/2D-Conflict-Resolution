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
		LoadScene ("MainMenu");

	}
	
}
