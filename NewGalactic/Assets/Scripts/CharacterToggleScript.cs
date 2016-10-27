using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterToggleScript : Photon.PunBehaviour {

    SpriteRenderer sr;
    int index = 0;
    //array that corresponds to prefabs of the diff characters
    Color[] colors = { Color.cyan, Color.green, Color.red, Color.white, Color.yellow, Color.blue, Color.magenta};

	// Use this for initialization
	void Start () {
		GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
		GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
		GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
				GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
				GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
				GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;

            //SceneManager.LoadScene("Instructions");
			((LevelManager)GameObject.FindObjectOfType<LevelManager>()).LoadScene("Instructions");
        }
	    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index = Mathf.Abs((index + 1) % colors.Length);
            updateSprite();
			GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
			GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
			GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index = Mathf.Abs((index + 1) % colors.Length);
            updateSprite();
			GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
			GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
			GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;
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
