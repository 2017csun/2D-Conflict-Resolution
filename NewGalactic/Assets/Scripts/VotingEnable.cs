using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VotingEnable : Photon.PunBehaviour {

	public Button voteOtherButton;
	public static bool isMaster = false;

	// Use this for initialization
	void Start () {
		GameObject.FindObjectOfType<GamePlanner> ().currentRound += 1;
		if(PhotonNetwork.player.isMasterClient){
			GameObject.FindObjectOfType<GamePlanner> ().RefreshValue ();
		}



		if (!PhotonNetwork.player.isMasterClient) {
			//ApplyCharacterScript.isReadyToNextLevel = true;
		} else {
			voteOtherButton.gameObject.SetActive (false);
			//ApplyCharacterScript.otherPlayerIsReadyToNextLevel = true;
			isMaster = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
