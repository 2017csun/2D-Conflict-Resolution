using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterEnterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var nameObject = gameObject.GetComponent<InputField>();
            PlayerPrefs.SetString("name", nameObject.text);
        }
    }
}