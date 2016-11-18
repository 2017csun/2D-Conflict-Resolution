using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintScore : Photon.PunBehaviour {

	bool hasPrintedScore = false;
	int correctteam = 0;
	bool oneMoreTime = false;

	public GameObject firstScore;
	// Use this for initialization
	void Start () {
		//Time.fixedDeltaTime = .1f;
		GameObject.FindObjectOfType<GamePlanner> ().currentRound += 1;
		if(PhotonNetwork.player.isMasterClient){
			GameObject.FindObjectOfType<GamePlanner> ().RefreshValue ();
		}
		StartCoroutine(UpdateScore());
	}


	// Update is called once per frame
	void FixedUpdate () {
		/*if (!hasPrintedScore) {
			ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();
			//correctteam = (sm.GetProsConsCorrectTeam ());
			GetComponent<Text> ().text = "Score:\n" +
			"   Your Score: " + sm.prosconsCorrectRound +
			"\n + Partner Score: " + sm.prosconsCorrectPartner +
			"\n_________________" +
			"\nTotal Round Score: " + (sm.GetProsConsCorrectRound () +
			"\n\n\n\n\n\n\n\n Total Team Score: " + correctteam);
			hasPrintedScore = true;
		} else if (!oneMoreTime) {
			ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();
			correctteam = (sm.GetProsConsCorrectTeam ());
			GetComponent<Text> ().text = "Score:\n" +
				"   Your Score: " + sm.prosconsCorrectRound +
				"\n + Partner Score: " + sm.prosconsCorrectPartner +
				"\n_________________" +
				"\nTotal Round Score: " + (sm.GetProsConsCorrectRound () +
					"\n\n\n\n\n\n\n\n Total Team Score: " + correctteam);
			oneMoreTime = true;
		} else {
			ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();
			GetComponent<Text> ().text = "Score:\n" +
				"   Your Score: " + sm.prosconsCorrectRound +
				"\n + Partner Score: " + sm.prosconsCorrectPartner +
				"\n_________________" +
				"\nTotal Round Score: " + (sm.GetProsConsCorrectRound () +
					"\n\n\n\n Total Team Score: " + correctteam);
		}*/
	}

	IEnumerator UpdateScore(){
		yield return new WaitForSeconds(.8f);
		//ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();

		firstScore.GetComponent<CountUp> ().SendScore ();
		//correctteam = (sm.GetProsConsCorrectTeam ());
		/*GetComponent<Text> ().text = "Score:\n" +
			"   Your Score: " + sm.prosconsCorrectRound +
			"\n + Partner Score: " + sm.prosconsCorrectPartner +
			"\n_________________" +
			"\nTotal Round Score: " + (sm.GetProsConsCorrectRound () +
				"\n\n\n\n\n\n Total Team Score: " + correctteam);*/
	}
}
