using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingText : Photon.PunBehaviour {

	bool isVis = true;
	float elapsedTime = 0f;
	public bool isAuto = false;
	public Text textToBlink;

	// Use this for initialization
	void Start () {
		elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAuto) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime > 0.5f) {
				if (isVis) {
					if (elapsedTime > 1f) {
						BlinkOff ();
					}
				} else {
					BlinkOn ();
				}
			}
		}
	}

	public void BlinkOff(){
		if (textToBlink != null) {
			textToBlink.color = new Color (1f, 1f, 1f, 0f);
			isVis = false;
			elapsedTime = 0f;
		}
	}

	public void BlinkOn(){
		if (textToBlink != null) {
			
			textToBlink.color = new Color (1f, 1f, 1f, 1f);
			isVis = true;
			elapsedTime = 0f;
		}
	}
}
