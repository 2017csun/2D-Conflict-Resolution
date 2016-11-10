using UnityEngine;
using System.Collections;

public class LaserShrink : MonoBehaviour {

	public float totalTime;
	float elapsedTime = 0f;
	bool isShrinking = false;
	public GameObject beam;
	float origYScale;
	// Use this for initialization
	void Start () {
		origYScale = beam.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (isShrinking) {
			elapsedTime += Time.deltaTime;
			if (totalTime - elapsedTime <= 0f) {
				EndShrink ();
			} else {
				beam.transform.localScale = new Vector2(beam.transform.localScale.x, (origYScale-(elapsedTime/totalTime)));
			}
		}
	}

	public void StartShrink(){
		isShrinking = true;
	}

	public void EndShrink(){
		isShrinking = false;
		beam.SetActive (false);
	}
}
