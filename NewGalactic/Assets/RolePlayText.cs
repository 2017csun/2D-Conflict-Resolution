using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RolePlayText : Photon.PunBehaviour {

	public Text theText;

	// Use this for initialization
	void Start () {
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
		case 5:
			// passed over for promotion
			if (PhotonNetwork.player.isMasterClient) {
				s = "Captain";
				p = "Chief Officer";

			} else {
				s = "Chief Officer";
				p = "Captain";

			}
			break;
		case 6:
			// unresolved issues
			if (PhotonNetwork.player.isMasterClient) {
				s = "Captain";
				p = "Chief Officer";

			} else {
				s = "Chief Officer";
				p = "Captain";

			}
			break;
		default:
			// confidentiality breach
			if (PhotonNetwork.player.isMasterClient) {
				s = "Lieutenant Commander";
				p = "Fleet Commander";

			} else {
				s = "Fleet Commander";
				p = "Lieutenant Commander";

			}
			break;
		}
		theText.text = "Your role: " + s + "\n\nPartner: " + p + "\n";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RevealIntentions(){
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
		case 5:
			// passed over for promotion
			if (PhotonNetwork.player.isMasterClient) {
				s = "Captain";
				p = "Chief Officer";

			} else {
				s = "Chief Officer";
				p = "Captain";

			}
			break;
		case 6:
			// unresolved issues
			if (PhotonNetwork.player.isMasterClient) {
				s = "Captain";
				p = "Chief Officer";

			} else {
				s = "Chief Officer";
				p = "Captain";

			}
			break;
		default:
			// confidentiality breach
			if (PhotonNetwork.player.isMasterClient) {
				s = "Lieutenant Commander";
				p = "Fleet Commander";

			} else {
				s = "Fleet Commander";
				p = "Lieutenant Commander";

			}
			break;
		}

		string q = "";
		string f = "";

		GamePlanner go = GameObject.FindObjectOfType<GamePlanner> ();
		if (PhotonNetwork.player.isMasterClient) {
			int myint = go.currentIntention % 5;
			int otherInt = go.currentOtherPlayersIntention % 5;
			q = go.intentionToString (myint);
			f = go.intentionToString (otherInt);
		} else {
			int myint = go.currentIntention % 5;
			int otherInt = go.currentOtherPlayersIntention % 5;
			q = go.intentionToString (myint);
			f = go.intentionToString (otherInt);
		}

		theText.text = "Your role: " + s + "\n" + "(" + q + ")\n" + "Partner: " + p + "\n" + "(" + f + ")";

	}
}
