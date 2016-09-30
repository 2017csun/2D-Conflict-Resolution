using UnityEngine;
using UnityEditor;
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
            Debug.Log("Right arrow pressed");
            sr = gameObject.GetComponent<SpriteRenderer>();
            Debug.Log(sr.sprite.texture);
            sr.sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Character/Asteroid.png", typeof(Sprite));
        }
	}

    public void OnToggle()
    {
        Debug.Log("Character toggled.");
    }
}
