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
            "Procrastinating on work because people avoid each other",
            "Others feeling resentful as their concerns are neglected",
            "People walking on eggshells instead of speaking candidly with each other",
        };
    }
    private string[] getCorrectAnswers()
    {
        return new string[]
        {
            "Sacrificing own interests and views",
            "Responding with less motivation because agreeing to things that are not of interest",
            "Losing people’s respect because constantly agreeing and not challenging ideas",
        };
    }
    // Update is called once per frame
    void Update () {
	
	}
}
