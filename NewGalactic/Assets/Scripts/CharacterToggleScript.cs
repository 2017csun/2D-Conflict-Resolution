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
		GameObject.FindObjectOfType<GamePlanner> ().currentRound += 1;
		if(PhotonNetwork.player.isMasterClient){
			GameObject.FindObjectOfType<GamePlanner> ().RefreshValue ();
		}
		index = 0;
		GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
		GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
		GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;

		updateSprite ();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
			CharManager cm = GameObject.FindObjectOfType<CharManager> ();
				cm.redChar1 = colors [index].r;
				cm.greenChar1 = colors [index].g;
				cm.blueChar1 = colors [index].b;

            //SceneManager.LoadScene("Instructions");
			if (!(cm.redChar1 == cm.redChar2 && cm.greenChar1 == cm.greenChar2 && cm.blueChar1 == cm.blueChar2)) {
				GameObject.FindObjectOfType<LevelManager> ().CheckForOtherPlayer ("Instructions");
			}
        }
	    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
			index--;
			if (index < 0) {
				index = 0;
			}
            updateSprite();
			GameObject.FindObjectOfType<CharManager> ().redChar1 = colors [index].r;
			GameObject.FindObjectOfType<CharManager> ().greenChar1 = colors [index].g;
			GameObject.FindObjectOfType<CharManager> ().blueChar1 = colors [index].b;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
			index++;
			if (index >= colors.Length) {
				index = colors.Length - 1;
			}
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
