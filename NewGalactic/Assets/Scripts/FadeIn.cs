using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : Photon.PunBehaviour {

	public float fadeInTime = 1f;
	private Image fadePanel;
	private Color currentColor = Color.black;


	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else if (!GameObject.FindObjectOfType<LevelManager>().shouldFadeToBlack){
			gameObject.SetActive (false);
		}
	}
}
