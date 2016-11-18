using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DefaultRolePlayPrep : Photon.PunBehaviour {
	public Text t;
	// Use this for initialization
	void Start () {
		string s = "";
		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			s = "Compromising";
			break;
		case 1: // competing
			s = "Competing";

			break;
		case 2: //collaborating
			s = "Collaborating";

			break;
		case 3: // avoiding
			s = "Avoiding";

			break;
		case 4: // accomodating
			s = "Accommodating";

			break;
		default:
			s = "Accommodating";

			break;
		}
		t.text = "Your Intention:\n" + s;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
