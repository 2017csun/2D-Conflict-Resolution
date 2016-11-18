using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountUp : Photon.PunBehaviour {

	float countTime;
	int currNum;
	int score;
	bool readyToCount = false;
	public GameObject nextCounter = null;
	public int ScoreIndex = 0;

	// Use this for initialization
	void Start () {
		countTime = 0f;
		currNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (readyToCount) {
			if (currNum <= score) {
				if (countTime > .05f) {
					this.GetComponent<Text> ().text = currNum.ToString ("00");
					currNum++;
					countTime = 0f;
				} else {
					countTime += Time.deltaTime;
				}
			} else {
				if (nextCounter != null) {
					nextCounter.GetComponent<CountUp> ().SendScore ();
					readyToCount = false;
				}
			}
		} 
	}

	public void SendScore(){
		this.GetComponent<Text> ().text = "00";
		ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();


		currNum = 0;
		countTime = 0f;
		switch (ScoreIndex) {
		case 0:
			score = sm.prosconsCorrectRound;
			break;
		case 1:
			score = sm.prosconsCorrectPartner;
			break;
		case 2:
			score = sm.GetProsConsCorrectRound ();
			break;
		case 3:
			int correctteam = (sm.GetProsConsCorrectTeam ());
			score = correctteam;
			break;
		default:
			score = 0;
			break;
		}
		//this.GetComponent<Text> ().text = score.ToString ("00");


		readyToCount = true;
	}
}
