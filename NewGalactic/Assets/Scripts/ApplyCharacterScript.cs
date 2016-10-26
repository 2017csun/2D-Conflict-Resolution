using UnityEngine;
using System.Collections;

public class ApplyCharacterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var sr = gameObject.GetComponent<SpriteRenderer>();
        var color = new Color(
            PlayerPrefs.GetFloat("red"),
            PlayerPrefs.GetFloat("green"),
            PlayerPrefs.GetFloat("blue"),
            1.0f
         );
        sr.color = color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
