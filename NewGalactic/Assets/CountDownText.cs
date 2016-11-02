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
		textToCount.text = "" + ((int)timeLeft/60).ToString("00") + ":" + (((int)timeLeft)%60).ToString("00");
		transporter.SetActive (false);
		/*bt.isAuto = false;
		if (timeLeft < 10) {
			bt.isAuto = true;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldCountDown) {
			secondCount += Time.deltaTime;

			if (secondCount > 1f) {
				if (timeLeft <= 10) {
					bt.BlinkOff ();
				}
				timeLeft -= 1f;
				//textToCount.text = "00:0" + (int)timeLeft;
				textToCount.text = "" + ((int)timeLeft/60).ToString("00") + ":" + (((int)timeLeft)%60).ToString("00");
				secondCount = 0f;
				if (timeLeft < 0f) {
					shouldCountDown = false;
					transporter.SetActive (true);
				}
			} else if (secondCount > .4f) {
				if (timeLeft <= 10) {
					bt.BlinkOn ();
				}
			}
		}
	}

	void TimerStart(){
		shouldCountDown = true;
	}
}
