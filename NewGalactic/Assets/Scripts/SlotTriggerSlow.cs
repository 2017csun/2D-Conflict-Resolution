using UnityEngine;
using System.Collections;

public class SlotTriggerSlow : MonoBehaviour {

	public SpriteRenderer laserSprite;
	public Animator slotAnimator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.CompareTag ("Player")) {
			Debug.Log ("Setting trigger");
			slotAnimator.SetTrigger ("SlowToCompeting");
		}
	}

	public void laserDisappear(){
		laserSprite.enabled = false;
	}
}
