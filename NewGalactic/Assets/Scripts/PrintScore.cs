using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintScore : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {

		ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();
		GetComponent<Text> ().text = "Score:\n" +
			"   Number of resolved votes: " + sm.GetResolvedNumRound () +
			"\n - Number of unresolved votes: " + sm.GetUnresolvedNumRound () +
			"\n   Number of Pros/Cons correct: " + sm.GetProsConsCorrectRound () +
			"\n - Number of Pros/Cons incorrect: " + sm.GetProsConsIncorrectRound () +
			"\n_________________" +
			"\nTotal: " + (sm.GetResolvedNumRound () - sm.GetUnresolvedNumRound () + sm.GetProsConsCorrectRound() - sm.GetProsConsIncorrectRound () +
			"\n\n\n\n Total Team Score: " + (sm.GetResolvedNumTeam() - sm.GetUnresolvedNumTeam() + sm.GetProsConsCorrectTeam() - sm.GetProsConsIncorrectTeam()));
	}


	// Update is called once per frame
	void Update () {

	}
}
