using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaitingTextAnimate : Photon.PunBehaviour {

	float animateTime = 0f;
	string[] textString = { "Waiting for Other Player.", "Waiting for Other Player..", "Waiting for Other Player..." };
	//Text waitingText;
	int currentIndex = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		animateTime += Time.deltaTime;
		if (animateTime > .4f) {
			currentIndex++;
			if (currentIndex > 2) {
				currentIndex = 0;
			}
			GetComponent<Text>().text = textString [currentIndex];
			animateTime = 0f;
		}
	
	}
}
