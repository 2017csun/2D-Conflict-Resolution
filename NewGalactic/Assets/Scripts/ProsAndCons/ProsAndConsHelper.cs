using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ProsAndConsHelper : MonoBehaviour
{
    private static int proCount = 0;
    private static int conCount = 0;
    static public void populateButtons(
        GameObject gameObject,
        string[] correctAnswers,
        string[] wrongAnswers,
        bool isPro
        )
    {

        bool[] indeces = generateIndeces();
        Button[] children = gameObject.GetComponentsInChildren<Button>();
        int buttonCounter = 0;
        int trueCounter = 0;

        System.Random random = new System.Random();
        foreach (Button button in children)
        {
            Text text = button.GetComponentInChildren<Text>();
            if (indeces[buttonCounter] == true && trueCounter < 3)
            {
                text.text = correctAnswers[trueCounter];
                trueCounter++;
            }
            else
            {
                int index = (int)random.Next(0, wrongAnswers.Length - 1);
                text.text = wrongAnswers[index];
            }
            button.onClick.AddListener(() => turnBlue(text, isPro));
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
        return indeces;
    }
    static void turnBlue(Text text, bool isPro)
    {
        Debug.Log(isPro);
        Debug.Log(conCount);
        if (text.color == Color.blue)
        {
            text.color = Color.black;
            if (isPro)
            {
                proCount--;
            } else
            {
                conCount--;
            }
        } else
        {
            if (isPro)
            {
                if (proCount < 3)
                {
                    text.color = Color.blue;
                    proCount++;
                }
            } else
            {
                if (conCount < 3)
                {
                    text.color = Color.blue;
                    conCount++;
                }
            }
        }
    }
}