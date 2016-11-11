using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProsAndConsButtonsScript : MonoBehaviour {

    GameObject prosList;
    GameObject consList;
    bool finished;

	public Text intentionLabel;
	// Use this for initialization
	void Start () {
        finished = false;
        gameObject.GetComponent<Button>().onClick.AddListener(()=>Submit());

        prosList = transform.Find("ProButtonList") ? transform.Find("ProButtonList").gameObject : null;
        consList = transform.Find("ConButtonList") ? transform.Find("ConButtonList").gameObject : null;

		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			intentionLabel.text = "Compromising";
			break;
		case 1: // competing
			intentionLabel.text = "Competing";

			break;
		case 2: //collaborating
			intentionLabel.text = "Collaborating";

			break;
		case 3: // avoiding
			intentionLabel.text = "Avoiding";

			break;
		case 4: // accomodating
			intentionLabel.text = "Accommodating";

			break;
		default:
			intentionLabel.text = "Accommodating";

			break;
		}
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && finished)
        {
            if (prosList != null)
            {
                GameObject.FindObjectOfType<LevelManager>().CheckForOtherPlayer("ConsScene");
            }
            else
            {
                GameObject.FindObjectOfType<LevelManager>().CheckForOtherPlayer("Scoring");
            }
			//PhotonNetwork.LoadLevel("Scoring");

        }
    }
    public void Submit ()
    {
        finished = true;
        Button button = gameObject.GetComponent<Button>();
        button.enabled = false;
        button.GetComponentInChildren<Text>().text = "Press Enter to continue";
        
        if (prosList != null)
        {
            ProsAndConsHelper.ShowAnswers(prosList, true);
        }
        else
        {
            ProsAndConsHelper.ShowAnswers(consList, false);
        }
    }
}
