using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadableTrigger : Photon.PunBehaviour {

	[SerializeField] string stringToShow;
	[SerializeField] string firstPersonString;
	public ReadableManager readableMan;
	public LaserShrink laserToStart;

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
		Debug.Log ("In update text of trig, should first person is " + readableMan.shouldFirstPerson);
		readableMan.UpdateText (readableMan.shouldFirstPerson ? firstPersonString : stringToShow, this);
	}
}
