using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterToggleScript : MonoBehaviour {

    SpriteRenderer sr;
    int index = 0;
    //array that corresponds to prefabs of the diff characters
    Color[] colors = { Color.cyan, Color.green, Color.red, Color.white, Color.yellow, Color.blue, Color.magenta};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetFloat("red", colors[index].r);
            PlayerPrefs.SetFloat("green", colors[index].g);
            PlayerPrefs.SetFloat("blue", colors[index].b);

            SceneManager.LoadScene("Level");
        }
	    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index = Mathf.Abs((index + 1) % colors.Length);
            updateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index = Mathf.Abs((index + 1) % colors.Length);
            updateSprite();
        }


    }
    private void updateSprite()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        var color = colors[index];
        color.a = 0.5f;
        sr.color = color;
    }
    public void OnToggle()
    {
        Debug.Log("Character toggled.");
    }
}
