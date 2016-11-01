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
    private static bool[] correctProIndeces;
    private static bool[] correctConIndeces;
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
        } else
        {
            correctConIndeces = indeces;
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
        if (text.color == Color.blue)
        {
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
                    text.color = Color.blue;
                    proCount++;
                }
            }
            else
            {
                if (conCount < 3)
                {
                    text.color = Color.blue;
                    conCount++;
                }
            }
        }
    }
    static private void showAnswerForList(GameObject list, bool[] indeces)
    {
        Button[] buttons = list.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Text text = buttons[i].GetComponentInChildren<Text>();
            if (indeces[i])
            {
                text.color = Color.green;
            }
            else if (text.color == Color.blue)
            {
                text.color = Color.red;
            }
            buttons[i].enabled = false;
        }
    }
    static public void ShowAnswers(GameObject list, bool isPro)
    {
        
        if (isPro)
        {
            showAnswerForList(list, correctProIndeces);
        }
        else
        {
            showAnswerForList(list, correctConIndeces);
        }
    }
}