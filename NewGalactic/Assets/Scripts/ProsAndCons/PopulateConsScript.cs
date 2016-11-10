using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulateConsScript : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        string[] wrongAnswers = this.getWrongAnswers();
        string[] correctAnswers = this.getCorrectAnswers();
        ProsAndConsHelper.populateButtons(gameObject, correctAnswers, wrongAnswers, false);

    }
    private string[] getWrongAnswers()
    {
		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			return new string[] {
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		case 1: // competing
			return new string[] {
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		case 2: //collaborating
			return new string[]
			{
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		case 3: // avoiding
			return new string[]
			{
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		case 4: // accomodating
			return new string[] {
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
			};
			break;
		default:
			return new string[] {
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
			};
			break;
		}
    }
	/*
	"Straining work relationships as people develop resentment",
	"Not exchanging information freely",
	"Escalating conflict and creating deadlock negotiations by using extreme tactics",
	"Involving  a lot of time, full concentration, and creativity ",
	"Psychologically demanding to be open to new ideas",
	"Causing hurt feelings by discussing sensitive issues",
	"Developing feelings of frustration if issue not fully resolved",
	"Creating superficial understandings because  issue only partially resolved",
	"Diminishing the quality of  the decision due to less innovation in the decision",
	"Procrastinating on work because people avoid each other",
	"Others feeling resentful as their concerns are neglected",
	"People walking on eggshells instead of speaking candidly with each other",
	"Sacrificing own interests and views",
	"Responding with less motivation because agreeing to things that are not of interest",
	"Losing people’s respect because constantly agreeing and not challenging ideas",
*/
    private string[] getCorrectAnswers()
    {
		switch(GameObject.FindObjectOfType<GamePlanner>().currentIntention){
		case 0: //compromising
			return new string[] {
				"Developing feelings of frustration if issue not fully resolved",
				"Creating superficial understandings because  issue only partially resolved",
				"Diminishing the quality of  the decision due to less innovation in the decision",
			};
			break;
		case 1: // competing
			return new string[] {
				"Straining work relationships as people develop resentment",
				"Not exchanging information freely",
				"Escalating conflict and creating deadlock negotiations by using extreme tactics",
			};
			break;
		case 2: //collaborating
			return new string[] {
				"Involving  a lot of time, full concentration, and creativity ",
				"Psychologically demanding to be open to new ideas",
				"Causing hurt feelings by discussing sensitive issues",
			};
			break;
		case 3: // avoiding
			return new string[] {
				"Procrastinating on work because people avoid each other",
				"Others feeling resentful as their concerns are neglected",
				"People walking on eggshells instead of speaking candidly with each other",
			};
			break;
		case 4: // accomodating
			return new string[]
			{
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		default:
			return new string[]
			{
				"Sacrificing own interests and views",
				"Responding with less motivation because agreeing to things that are not of interest",
				"Losing people’s respect because constantly agreeing and not challenging ideas",
			};
			break;
		}
        
    }
    // Update is called once per frame
    void Update () {
	
	}
}
