using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

class ProsAndConsHelper : Photon.PunBehaviour
{
    private static int proCount = 0;
    private static int conCount = 0;
    private static bool[] correctProIndeces;
    private static bool[] correctConIndeces;

	private static List<int> wrongIndexes = new List<int>();


    static public void populateButtons(
        GameObject gameObject,
        string[] correctAnswers,
        string[] wrongAnswers,
        bool isPro
        )
    {

        bool[] indeces = generateIndeces();
        if (isPro)
        {
            correctProIndeces = indeces;
			proCount = 0;
        } else
        {
            correctConIndeces = indeces;
			conCount = 0;
        }
        Button[] children = gameObject.GetComponentsInChildren<Button>();
        int buttonCounter = 0;
        int trueCounter = 0;

        System.Random random = new System.Random();
        for(int i = 0; i < children.Length; i++)
        {
            Button button = children[i];
            Text text = button.GetComponentInChildren<Text>();
            if (indeces[i] == true && trueCounter < 3)
            {
                text.text = correctAnswers[trueCounter];
                trueCounter++;
            }
            else
            {
				int index;
				do{
					index = (int)random.Next(0, wrongAnswers.Length - 1);
				} while (wrongIndexes.Contains(index));
				wrongIndexes.Add (index);
				text.text = wrongAnswers[index];
            }
            button.onClick.AddListener(() => turnBlue(text, isPro));
        }
		Button[] buttons = gameObject.GetComponentsInChildren<Button>();
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].enabled = true;
			buttons[i].GetComponentInChildren<Text>().color = Color.black;


		}
    }
    static public bool[] generateIndeces()
    {
        bool[] indeces = new bool[6];
        System.Random random = new System.Random();
        int numTrue = 0;
        //PSEUDO RANDOM PRO/CON POSITIONING GENERAtION
        for (int i = 0; i < 6; i++)
        {
            int rnd = random.Next(6);
            if (rnd > 2)
            {
                indeces[i] = false;
            }
            else
            {
                indeces[i] = true;
                numTrue++;
            }
        }
        if (numTrue < 3)
        {
            for (int i = 5; i >= 0; i--)
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
        else if (numTrue > 3)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (indeces[i] == true)
                {
                    indeces[i] = false;
                    numTrue--;
                    if (numTrue == 3)
                    {
                        i = -1;
                    }
                }
            }
        }
        return indeces;
    }
    static void turnBlue(Text text, bool isPro)
    {
		Transform parent = text.transform.parent;
		Toggle tog = parent.GetComponentInChildren<Toggle> ();
        if (text.color == Color.blue)
        {
			tog.isOn = false;
            text.color = Color.black;
            if (isPro)
            {
                proCount--;
            }
            else
            {
                conCount--;
            }
        }
        else
        {
            if (isPro)
            {
                if (proCount < 3)
                {
					tog.isOn = true;
                    text.color = Color.blue;
                    proCount++;
                }
            }
            else
            {
                if (conCount < 3)
                {
					tog.isOn = true;
                    text.color = Color.blue;
                    conCount++;
                }
            }
        }
    }
	static private void showAnswerForList(GameObject list, bool[] indeces, bool isPro)
    {
		int correct = 0;
		int incorrect = 0;
        Button[] buttons = list.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Text text = buttons[i].GetComponentInChildren<Text>();
            if (indeces[i])
            {
				if (text.color == Color.blue) {
					correct++;
				}
				text.color = new Color(0f,.5f, 0f);
            }
            else if (text.color == Color.blue)
            {
				incorrect++;
                text.color = Color.red;
            }
            buttons[i].enabled = false;
        }
		if (isPro) {
			GameObject.FindObjectOfType<ScoringManager>().SetProsCorrect(correct);
			GameObject.FindObjectOfType<ScoringManager>().SetProsIncorrect(incorrect);
		} else {
			GameObject.FindObjectOfType<ScoringManager>().SetConsCorrect(correct);
			GameObject.FindObjectOfType<ScoringManager>().SetConsIncorrect(incorrect);
		}

    }
    static public void ShowAnswers(GameObject list, bool isPro)
    {
        
        if (isPro)
        {
			showAnswerForList(list, correctProIndeces, isPro);
        }
        else
        {
			showAnswerForList(list, correctConIndeces, isPro);
        }
    }
}