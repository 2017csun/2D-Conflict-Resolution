using UnityEngine;
using System.Collections;

public class ReadableTrigger : MonoBehaviour {

	[SerializeField] string stringToShow;
	public ReadableManager readableMan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		readableMan.UpdateText (stringToShow);
	}
}
