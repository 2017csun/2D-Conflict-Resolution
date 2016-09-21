using UnityEngine;
using System.Collections;

public class DoorTransporter : MonoBehaviour {

	bool canTransport = false;
	public LevelManager lm;
	public string destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canTransport && Input.GetKey (KeyCode.UpArrow)) {
			lm.LoadScene (destination);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		canTransport = true;
	}

	void OnTriggerExit2D(Collider2D other){
		canTransport = false;
	}
}
