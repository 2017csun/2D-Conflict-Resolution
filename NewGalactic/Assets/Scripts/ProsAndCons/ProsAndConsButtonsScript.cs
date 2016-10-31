using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProsAndConsButtonsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TurnBlue()
    {
        Debug.Log(gameObject);
        gameObject.GetComponent<Text>().color = Color.blue;
    }
}
