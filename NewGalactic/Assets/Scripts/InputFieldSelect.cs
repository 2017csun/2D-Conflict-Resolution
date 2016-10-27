using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<InputField>().Select();
		GetComponent<InputField>().ActivateInputField();
		//Input.eatKeyPressOnTextFieldFocus = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
