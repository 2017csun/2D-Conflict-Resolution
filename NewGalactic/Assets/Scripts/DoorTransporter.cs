using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
			lm.CheckForOtherPlayer (destination);
			/*if (ApplyCharacterScript.otherPlayerIsReadyToNextLevel) {
				/*NumberDetector[] dets = GameObject.FindObjectsOfType<NumberDetector> ();
				if (dets != null) {
					foreach (NumberDetector n in dets) {
						n.CheckForNums ();
					}
				}

				ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
				ApplyCharacterScript.isReadyToNextLevel = false;
				lm.LoadScene (destination);
			} else if (VotingEnable.isMaster && SceneManager.GetActiveScene ().buildIndex == 10) {
				NumberDetector[] dets = GameObject.FindObjectsOfType<NumberDetector> ();
				if (dets != null) {
					foreach (NumberDetector n in dets) {
						n.CheckForNums ();
					}
				}
				ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
				ApplyCharacterScript.isReadyToNextLevel = false;
				lm.LoadScene (destination);
			}*/
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
