using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterToggleScript : MonoBehaviour {

    SpriteRenderer sr;
    // vector to keep track of selected character/character options

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("enter pressed");
            SceneManager.LoadScene("Level");
        }
	    else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left arrow pressed");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            Debug.Log(Resources.Load("AsteroidSprite"));
            //change this later w/ more characters
            var next = Resources.Load("AsteroidSprite") as GameObject;
            sr.sprite = next.GetComponent<SpriteRenderer>().sprite;
        }
	}

    public void OnToggle()
    {
        Debug.Log("Character toggled.");
    }
}
