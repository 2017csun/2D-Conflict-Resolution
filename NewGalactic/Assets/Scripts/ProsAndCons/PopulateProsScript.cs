using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PopulateProsScript : MonoBehaviour {

    // Use this for initialization
    void Start () {

        string[] wrongAnswers = this.getWrongAnswers();
        string[] correctAnswers = this.getCorrectAnswers();
        ProsAndConsHelper.populateButtons(gameObject, correctAnswers, wrongAnswers, true);
        
    }
    void turnBlue()
    {
        Debug.Log("was clicked");
        gameObject.GetComponent<Text>().color = Color.blue;
    }
    // add logic for intentions here
    private string[] getWrongAnswers()
    {
        return new string[]
        {
            "Asserting your position so ideas are taken seriously",
            "Making quick decisions or achieving quick victory",
            "Protecting your interests and views from attack",
            "Working toward meeting both people’s concern",
            "Resolving problems in a relationship",
            "Getting to a situation that is good enough",
            "Seeking innovative solutions and creating synergy through the exchange of ideas",
            "Meeting half way to reduce relationship strain",
            "Reducing stress by evading unpleasant people and topics",
            "Gaining more time to be better prepared and be less distracted",
            "Not stirring up problems or provoking trouble",
        };
    }
    private string[] getCorrectAnswers()
    {
        return new string[]{
            "Helping people meet their needs",
            "Supporting people and calming people down",
            "Building social capital by doing favors",
        };
    }
	// Update is called once per frame
	void Update () {
	
	}
}
