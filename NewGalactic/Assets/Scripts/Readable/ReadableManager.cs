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

	public Text topText = null;
	public Text botText = null;
	// Use this for initialization
	void Start () {
		if (topText != null) {
			string s = "";
			string p = "";
			switch (GameObject.FindObjectOfType<GamePlanner> ().currentConflict) {
			case 0:
				// incomplete
				if (PhotonNetwork.player.isMasterClient) {
					s = "Captain";
					p = "Cadet";

				} else {
					s = "Cadet";
					p = "Captain";

				}
				break;
			case 1:
				// NEEDS REPLACING - meeting miscommunication
				// confidentiality breach
				if (PhotonNetwork.player.isMasterClient) {
					s = "Lieutenant of Communications";
					p = "Lieutenant of Navigation";

				} else {
					s = "Lieutenant of Navigation";
					p = "Lieutenant of Communications";

				}
				break;
			case 2:
				// NEEDS REPLACING - designdeploydelegate
				// unresolved issues
				if (PhotonNetwork.player.isMasterClient) {
					s = "Lieutenant Commander of Weapons";
					p = "Ensign";

				} else {
					s = "Ensign";
					p = "Lieutenant Commander of Weapons";

				}
				break;
			case 3:
				// discussion domination
				if (PhotonNetwork.player.isMasterClient) {
					s = "Physician's Assistant";
					p = "Lead Nurse";

				} else {
					s = "Lead Nurse";
					p = "Physician's Assistant";

				}
				break;
			case 4:
				// No Show no call
				if (PhotonNetwork.player.isMasterClient) {
					s = "Staff Officer of Communications";
					p = "Staff Officer of Technology";

				} else {
					s = "Staff Officer of Technology";
					p = "Staff Officer of Communications";

				}
				break;
			default:
				if (PhotonNetwork.player.isMasterClient) {
					s = "Captain";
					p = "Chief Officer";

				} else {
					s = "Chief Officer";
					p = "Captain";

				}
				break;
			}
			topText.text = "Your role: " + s;
			botText.text = "Partner: " + p;
		}
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
