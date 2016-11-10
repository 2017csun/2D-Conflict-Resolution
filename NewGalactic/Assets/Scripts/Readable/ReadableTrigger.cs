using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadableTrigger : Photon.PunBehaviour {

	//[SerializeField] string stringToShow;
	//[SerializeField] string firstPersonString;
	public ReadableManager readableMan;
	public LaserShrink laserToStart;

	public string incompleteassignmentsStringp1;
	public string meetingmiscommuncationStringp1;
	public string designdeploymentdelegationStringp1;
	public string passoverforpromotionStringp1;
	public string noshownocallStringp1;
	public string discussiondominationStringp1;

	public string incompleteassignmentsStringp2;
	public string meetingmiscommuncationStringp2;
	public string designdeploymentdelegationStringp2;
	public string passoverforpromotionStringp2;
	public string noshownocallStringp2;
	public string discussiondominationStringp2;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.GetComponent<PlayerControl> ().thisOneIsLocal) {
			updateText ();
			laserToStart.StartShrink ();
		}

	}

	public void updateText(){
		string s = "";
		switch (GameObject.FindObjectOfType<GamePlanner> ().currentConflict) {
		case 0:
			// incomplete
			if (PhotonNetwork.player.isMasterClient) {
				s = incompleteassignmentsStringp1;
			} else {
				s = incompleteassignmentsStringp2;
			}
			break;
		case 1:
			// NEEDS REPLACING - meeting miscommunication
			// confidentiality breach
			if (PhotonNetwork.player.isMasterClient) {
				s = meetingmiscommuncationStringp1;
			} else {
				s = meetingmiscommuncationStringp2;
			}
			break;
		case 2:
			// NEEDS REPLACING - designdeploydelegate
			// unresolved issues
			if (PhotonNetwork.player.isMasterClient) {
				s = designdeploymentdelegationStringp1;
			} else {
				s = designdeploymentdelegationStringp2;
			}
			break;
		case 3:
			// discussion domination
			if (PhotonNetwork.player.isMasterClient) {
				s = discussiondominationStringp1;
			} else {
				s = discussiondominationStringp2;
			}
			break;
		case 4:
			// No Show no call
			if (PhotonNetwork.player.isMasterClient) {
				s = noshownocallStringp1;
			} else {
				s = noshownocallStringp2;
			}
			break;
		default:
			if (PhotonNetwork.player.isMasterClient) {
				s = passoverforpromotionStringp1;
			} else {
				s = passoverforpromotionStringp2;
			}
			break;
		}
		readableMan.UpdateText (s , this);
	}
}