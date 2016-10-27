using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour {

	// Use this for initialization
	void Start () {

		ScoringManager sm = GameObject.FindObjectOfType<ScoringManager> ();
		GetComponent<Text> ().text = "Score:\n" +
		"   Number of resolved votes: " + sm.GetResolvedNum () +
		"\n - Number of unresolved votes: " + sm.GetUnresolvedNum () +
		"\n   Number of Pros/Cons correct: " + sm.GetProsConsCorrect () +
		"\n - Number of Pros/Cons incorrect: " + sm.GetProsConsIncorrect () +
		"\n____________________________________" +
			"\nTotal: " + (sm.GetResolvedNum () - sm.GetUnresolvedNum () + sm.GetProsConsCorrect() - sm.GetProsConsIncorrect ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
