using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PopulateProsScript : MonoBehaviour {
    private Button[] children;

    // Use this for initialization
    void Start () {
                //HARDCODED FOR ACCOMODATING FOR NOW...
        string[] wrongAnswers =
        {
            "Asserting your position so ideas are taken seriously",
            "Seeking innovative solutions and creating synergy through the exchange of ideas",
            "Meeting half way to reduce relationship strain",
            "Gaining more time to be better prepared and be less distracted",
            "Resolving problems in a relationship",
            "Not stirring up problems or provoking trouble",
        };
       string[] correctAnswers =
        {
            "Helping people meet their needs",
            "Supporting people and calming people down",
            "Building social capital by doing favors",
        };

    bool[] indeces = this.generateIndeces();
        Debug.Log(indeces);
        children = gameObject.GetComponentsInChildren<Button>();
        int buttonCounter = 0;
        int trueCounter = 0;
        foreach(Button button in children)
        {
            if (indeces[buttonCounter] == true && trueCounter < 3)
            {
                button.GetComponentInChildren<Text>().text = correctAnswers[trueCounter];
                trueCounter++;
            }
            else
            {
                int index = wrongAnswers.Length - trueCounter - buttonCounter + 1;
                if (index >= wrongAnswers.Length)
                {
                    index--;
                }
                else if (index < 0)
                {
                    index = 0;
                }
                button.GetComponentInChildren<Text>().text = wrongAnswers[index];
            }
            buttonCounter++;
        }
	}
	private bool[] generateIndeces()
    {
        bool[] indeces = new bool[5];
        System.Random random = new System.Random();
        int numTrue = 0;
        //PSEUDO RANDOM PRO/CON POSITIONING GENERAtION
        for (int i = 0; i < 5; i++)
        {
            int rnd = random.Next(0, 4);
            if (rnd > 1)
            {
                indeces[i] = false;
            }
            else
            {
                indeces[i] = true;
                numTrue++;
            }
        }
        if (numTrue != 3)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (indeces[i] == false)
                {
                    indeces[i] = true;
                    numTrue++;
                    if (numTrue == 3)
                    {
                        i = -1;
                    }
                }
            }
        }
        return indeces;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
