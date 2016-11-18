using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProsAndConsButtonsScript : Photon.PunBehaviour {

    GameObject prosList = null;
    GameObject consList = null;
    bool finished;

	public Text intentionLabel;
	public GameObject transporter;

	public Button submitButton;
	// Use this for initialization
	void Start () {
		Debug.Log ("Hello beginning!");

        finished = false;
        //gameObject.GetComponent<Button>().onClick.AddListener(()=>Submit());

		if (GameObject.Find ("ProButtonList") != null) {
			prosList = GameObject.Find ("ProButtonList").gameObject;
		} else if (GameObject.Find ("ConButtonList") != null) {
			consList = GameObject.Find ("ConButtonList").gameObject;
		}

		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			intentionLabel.text = "C o m p r o m i s i n g";
			break;
		case 1: // competing
			intentionLabel.text = "C o m p e t i n g";

			break;
		case 2: //collaborating
			intentionLabel.text = "C o l l a b o r a t i n g";

			break;
		case 3: // avoiding
			intentionLabel.text = "A v o i d i n g";

			break;
		case 4: // accomodating
			intentionLabel.text = "A c c o m m o d a t i n g";

			break;
		default:
			intentionLabel.text = "A c c o m m o d a t i n g";

			break;
		}
		Debug.Log ("Hello world!");
		transporter.SetActive (false);
        
	}

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Return) && finished)
        {
			GameObject.FindObjectOfType<LevelManager>().CheckForOtherPlayer("Scoring");
			//PhotonNetwork.LoadLevel("Scoring");

        }*/
    }
    public void Submit ()
    {
        finished = true;
       // Button button = gameObject.GetComponent<Button>();
		submitButton.gameObject.SetActive(false);
        //button.GetComponentInChildren<Text>().text = "Press Enter to continue";
        
		if (prosList != null) {
			GameObject.FindObjectOfType<ProsAndConsHelper>().ShowAnswers (prosList, true);
		} 
		if (consList != null) {
			GameObject.FindObjectOfType<ProsAndConsHelper>().ShowAnswers (consList, false);
		}
		transporter.SetActive (true);

    }
}
