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
				switch (GameObject.FindObjectOfType<GamePlanner> ().currentIntention) {
				case 0:
					slotAnimator.SetTrigger ("SlowToCompromising");
					break;
				case 1:
					slotAnimator.SetTrigger ("SlowToCompeting");
					break;
				case 2:
					slotAnimator.SetTrigger ("SlowToCollaborating");
					break;
				case 3:
					slotAnimator.SetTrigger ("SlowToAvoiding");
					break;
				case 4:
					slotAnimator.SetTrigger ("SlowToAccommodating");
					break;
				default:
					slotAnimator.SetTrigger ("SlowToAccommodating");
					break;
				}
			}
		} else {
			if (collider.gameObject.CompareTag ("Player")) {
				switch (GameObject.FindObjectOfType<GamePlanner> ().currentConflict) {
				case 0:
					slotAnimator.SetTrigger ("SlowToCompromising");
					break;
				case 1:
					slotAnimator.SetTrigger ("SlowToCompeting");
					break;
				case 2:
					slotAnimator.SetTrigger ("SlowToCollaborating");
					break;
				case 3:
					slotAnimator.SetTrigger ("SlowToAvoiding");
					break;
				case 4:
					slotAnimator.SetTrigger ("SlowToAccommodating");
					break;
				default:
					slotAnimator.SetTrigger ("SlowToAccommodating");
					break;
				}
			}
		}
	}
}
