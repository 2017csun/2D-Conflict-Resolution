using UnityEngine;
using System.Collections;

public class Spinnable : MonoBehaviour {

	bool canSpin = false;
	public GameObject laser;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpin && Input.GetKey (KeyCode.UpArrow)) {
			StartSpin ();
			canSpin = false;
		}

		if (GetComponent<Rigidbody2D> ().angularVelocity < 10f && GetComponent<Rigidbody2D> ().angularVelocity > 1f) {
			GetComponent<Rigidbody2D> ().angularVelocity = 0f;
			laser.SetActive (false);
		}
	}

	public void StartSpin(){
		Debug.Log ("Adding torque");
		GetComponent<Rigidbody2D> ().AddTorque (1000f);

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			canSpin = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			canSpin = false;
		}
	}
}
