using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

    class ProsAndConsHelper : MonoBehaviour
    {
        static public void populateButtons(
            GameObject gameObject,
            string[] correctAnswers,
            string[] wrongAnswers
            )
        {

        bool[] indeces = generateIndeces();
        Button[] children = gameObject.GetComponentsInChildren<Button>();
        int buttonCounter = 0;
        int trueCounter = 0;

        System.Random random = new System.Random();
        foreach (Button button in children)
        {
            if (indeces[buttonCounter] == true && trueCounter < 3)
            {
                button.GetComponentInChildren<Text>().text = correctAnswers[trueCounter];
                trueCounter++;
            }
            else
            {
                int index = (int)random.Next(0, wrongAnswers.Length - 1);
                button.GetComponentInChildren<Text>().text = wrongAnswers[index];
            }
            buttonCounter++;
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
    }