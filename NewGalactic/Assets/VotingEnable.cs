using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VotingEnable : Photon.PunBehaviour {

	public Button voteOtherButton;
	public static bool isMaster = false;

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.player.isMasterClient) {
		} else {
			voteOtherButton.gameObject.SetActive (false);
			isMaster = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
