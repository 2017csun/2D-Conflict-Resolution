using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterToggleScript : MonoBehaviour {

    SpriteRenderer sr;
    int index = 0;
    //array that corresponds to prefabs of the diff characters
    string[] characters = { "AlienRobot" , "Asteroid" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetString("character", characters[index]);
            SceneManager.LoadScene("Level");
        }
	    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index = Mathf.Abs((index - 1) % characters.Length);
            updateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index = Mathf.Abs((index + 1) % characters.Length);
            updateSprite();
        }


    }
    private void updateSprite()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        var next = Resources.Load(characters[index]) as GameObject;
        sr.sprite = next.GetComponent<SpriteRenderer>().sprite;
    }
    public void OnToggle()
    {
        Debug.Log("Character toggled.");
    }
}
