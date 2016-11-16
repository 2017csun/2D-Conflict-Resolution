using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlanner : Photon.PunBehaviour {
	bool hasMadePlan = false;

	public List<int> conflictOrder;
	public List<int> intentionOrder;

	public int currentRound = 0;
	public int currentConflict = 0;
	public int currentIntention = 0;
	public int currentOtherPlayersIntention = 0;

	public static GamePlanner instance = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		//conflictOrder = new List<int> ();
		//intentionOrder = new List<int> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.player != null) {
			if (PhotonNetwork.player.isMasterClient && !hasMadePlan) {
				/*List<int> l = new List<int> ();
				for (int i = 0; i < 5; i++) {
					l.Add (i);
					i++;
				}

				while (l.Count > 0) {
					int index = Random.Range (0, l.Count);
					int rand = l [index];
					conflictOrder.Add (rand);
					l.RemoveAt (index);
				}

				List<int> l2 = new List<int> ();
				for (int i = 0; i < 5; i++) {
					l2.Add (i);
					i++;
				}

				while (l2.Count > 0) {
					int index = Random.Range (0, l2.Count);
					int rand = l2 [index];
					intentionOrder.Add (rand);
					l2.RemoveAt (index);
				}*/
				for (int i = 0; i < conflictOrder.Count; i++) {
					int temp = conflictOrder[i];
					int randomIndex = Random.Range(i, conflictOrder.Count);
					conflictOrder[i] = conflictOrder[randomIndex];
					conflictOrder[randomIndex] = temp;
				}

				for (int i = 0; i < intentionOrder.Count; i++) {
					int temp = intentionOrder[i];
					int randomIndex = Random.Range(i, intentionOrder.Count);
					intentionOrder[i] = intentionOrder[randomIndex];
					intentionOrder[randomIndex] = temp;
				}
				currentConflict = conflictOrder [currentRound%8];
				currentIntention = intentionOrder [currentRound%5];
				currentOtherPlayersIntention = intentionOrder [(currentRound + 2) % 5];
				hasMadePlan = true;
			} else if(PhotonNetwork.player.isMasterClient){
				//currentConflict = conflictOrder [currentRound%5];
				//currentIntention = intentionOrder [currentRound%5];
			}
		}
	}

	public void RefreshValue(){
		currentConflict = conflictOrder [currentRound%8];
		currentOtherPlayersIntention = intentionOrder [(currentRound + 2) % 5];
		currentIntention = intentionOrder [currentRound%5];
	}

	public string intentionToString(int intention){
		switch (intention) {
		case 0:
			return "Compromising";
			break;
		case 1:
			return "Competing";
			break;
		case 2:
			return "Collaborating";
			break;
		case 3:
			return "Avoiding";
			break;
		case 4:
			return "Accommodating";
			break;
		default:
			return "Accommodating";
			break;
		}
	}
}