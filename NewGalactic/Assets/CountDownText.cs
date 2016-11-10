using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownText : MonoBehaviour {

	public float timeLeft;
	bool shouldCountDown = false;
	float secondCount = 0f;
	public BlinkingText bt;
	public Text textToCount;
	public GameObject transporter;

	// Use this for initialization
	void Start () {
		TimerStart ();
		transporter.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (shouldCountDown) {
			secondCount += Time.deltaTime;

			if (secondCount > 1f) {

				bt.BlinkOff ();
				timeLeft -= 1f;
				textToCount.text = "00:0" + (int)timeLeft;
				secondCount = 0f;
				if (timeLeft < 0f) {
					shouldCountDown = false;
					transporter.SetActive (true);
				}
			} else if (secondCount > .4f) {
				bt.BlinkOn ();
			}
		}
	}

	void TimerStart(){
		shouldCountDown = true;
	}
}
