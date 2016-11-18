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
    // add logic for intentions here
    private string[] getWrongAnswers()
    {
		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			return new string[] {
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
				"Reducing stress by evading unpleasant people and topics",
				"Not stirring up problems or provoking trouble",
				"Gaining more time to be better prepared and be less distracted",
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		case 1: // competing
			return new string[] {
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Meeting half way to reduce relationship strain",
				"Reducing stress by evading unpleasant people and topics",
				"Not stirring up problems or provoking trouble",
				"Gaining more time to be better prepared and be less distracted",
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		case 2: //collaborating
			return new string[]
			{
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Meeting half way to reduce relationship strain",
				"Reducing stress by evading unpleasant people and topics",
				"Not stirring up problems or provoking trouble",
				"Gaining more time to be better prepared and be less distracted",
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		case 3: // avoiding
			return new string[]
			{
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Meeting half way to reduce relationship strain",
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		case 4: // accomodating
			return new string[]
			{
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Meeting half way to reduce relationship strain",
				"Reducing stress by evading unpleasant people and topics",
				"Gaining more time to be better prepared and be less distracted",
				"Not stirring up problems or provoking trouble",
			};
			break;
		default:
			return new string[]
			{
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Meeting half way to reduce relationship strain",
				"Reducing stress by evading unpleasant people and topics",
				"Gaining more time to be better prepared and be less distracted",
				"Not stirring up problems or provoking trouble",
			};
			break;
		}
        
    }

	/*
	"Asserting your position so ideas are taken seriously",
	"Making quick decisions or achieving quick victory",
	"Protecting your interests and views from attack",
	"Seeking innovative solutions and creating synergy through the exchange of ideas",
	"Working toward meeting both people’s concern",
	"Resolving problems in a relationship",
	"Getting to a situation that is good enough",
	"Providing equal gains and losses for both people",
	"Meeting half way to reduce relationship strain",
	"Reducing stress by evading unpleasant people and topics",
	"Not stirring up problems or provoking trouble",
	"Gaining more time to be better prepared and be less distracted",
	"Helping people meet their needs",
	"Supporting people and calming people down",
	"Building social capital by doing favors",
	*/

    private string[] getCorrectAnswers()
    {
		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			return new string[] {
				"Getting to a situation that is good enough",
				"Providing equal gains and losses for both people",
				"Meeting half way to reduce relationship strain",
			};
			break;
		case 1: // competing
			return new string[] {
				"Asserting your position so ideas are taken seriously",
				"Making quick decisions or achieving quick victory",
				"Protecting your interests and views from attack",
			};
			break;
		case 2: //collaborating
			return new string[] {
				"Seeking innovative solutions and creating synergy through exchanging ideas",
				"Working toward meeting both people’s concern",
				"Resolving problems in a relationship",
			};
			break;
		case 3: // avoiding
			return new string[] {
				"Reducing stress by evading unpleasant people and topics",
				"Not stirring up problems or provoking trouble",
				"Gaining more time to be better prepared and be less distracted",
			};
			break;
		case 4: // accomodating
			return new string[]
			{
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		default:
			return new string[]
			{
				"Helping people meet their needs",
				"Supporting people and calming people down",
				"Building social capital by doing favors",
			};
			break;
		}
    }
	// Update is called once per frame
	void Update () {
	
	}
}
