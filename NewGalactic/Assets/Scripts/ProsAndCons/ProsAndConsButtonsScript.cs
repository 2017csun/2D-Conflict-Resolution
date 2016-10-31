using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProsAndConsButtonsScript : MonoBehaviour {

    GameObject prosList;
    GameObject consList;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>Submit());

        prosList = transform.Find("ProButtonList").gameObject;
        consList = transform.Find("ConButtonList").gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Submit ()
    {
        Button button = gameObject.GetComponent<Button>();
        button.enabled = false;
        button.GetComponentInChildren<Text>().text = "Press Enter to continue";
        ProsAndConsHelper.ShowAnswers(prosList, true);
        ProsAndConsHelper.ShowAnswers(consList, false);
    }
}
