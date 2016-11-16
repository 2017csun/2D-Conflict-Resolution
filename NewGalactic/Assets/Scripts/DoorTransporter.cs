using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTransporter : MonoBehaviour {

	bool canTransport = false;
	public LevelManager lm;
	public string destination;
	public Text waitingText;
	public bool isProsCons = false;
	// Use this for initialization
	void Start () {
		waitingText.color = new Color(1,1,1,0);

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
		if (ApplyCharacterScript.isReadyToNextLevel) {
			Text[] ts = GameObject.FindObjectsOfType<Text> ();
			foreach (Text t in ts) {
				t.color = new Color(1,1,1,0);

			}
			waitingText.color = new Color(1,1,1,1);

			if (isProsCons) {
				GameObject[] imgs = GameObject.FindGameObjectsWithTag ("pcbutton");
				foreach (GameObject i in imgs) {
					i.SetActive (false);
				}
			} 
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
