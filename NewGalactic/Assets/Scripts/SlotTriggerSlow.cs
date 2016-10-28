using UnityEngine;
using System.Collections;

public class SlotTriggerSlow : Photon.PunBehaviour {

	public Animator slotAnimator;
	public bool isConflict = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){
		if (!isConflict) {
			if (collider.gameObject.GetComponent<PlayerControl> ().thisOneIsLocal) {
				Debug.Log ("Setting trigger");
				slotAnimator.SetTrigger ("SlowToAccommodating");
			}
		} else {
			if (collider.gameObject.CompareTag ("Player")) {
				Debug.Log ("Setting trigger");
				slotAnimator.SetTrigger ("SlowToAccommodating");
			}
		}
	}
}
