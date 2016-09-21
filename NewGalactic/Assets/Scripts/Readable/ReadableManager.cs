using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadableManager : MonoBehaviour {

	public Image arrowKey;
	public Text mainText;

	[SerializeField]
	string[] conflictScripts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateText(string newText){
		mainText.text = newText;
	}
		
}
