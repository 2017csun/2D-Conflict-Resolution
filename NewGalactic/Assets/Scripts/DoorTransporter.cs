﻿using UnityEngine;
using System.Collections;

public class DoorTransporter : MonoBehaviour {

	bool canTransport = false;
	public LevelManager lm;
	public string destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canTransport && Input.GetKey (KeyCode.DownArrow)) {
			ApplyCharacterScript.isReadyToNextLevel = true;
	
			if (ApplyCharacterScript.otherPlayerIsReadyToNextLevel) {
				ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
				ApplyCharacterScript.isReadyToNextLevel = false;
				lm.LoadScene (destination);
			}
			//lm.LoadScene (destination);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<PlayerControl> ().thisOneIsLocal) {
			canTransport = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.GetComponent<PlayerControl> ().thisOneIsLocal) {
			canTransport = false;
		}	
	}
}
