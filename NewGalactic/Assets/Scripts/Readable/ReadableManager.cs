using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadableManager : Photon.PunBehaviour {
	public bool shouldFirstPerson = true;
	public Image arrowKey;
	public Text mainText;
	public ReadableTrigger currTrigger = null;
	public Toggle firstp;

	public Text textToMute;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateText(string newText, ReadableTrigger rt){
		mainText.text = newText;
		currTrigger = rt;

	}

	public void SetShouldFirstPerson(){
		bool shouldFP = true;
		shouldFirstPerson = shouldFP;

		if (currTrigger != null) {
			currTrigger.updateText ();
		}
	}

	public void UpdateSimple(string simpleText){
		if (textToMute != null) {
			textToMute.gameObject.SetActive (false);
		}
		mainText.text = simpleText;
	}
		
}
