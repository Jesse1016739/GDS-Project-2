using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoringSys : MonoBehaviour
{
    public float currentScore = 0;
    public float maxScore = 999;

    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        //Debugging for score display
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            currentScore += 1;
        }
        */

        //Code to display the score, rounded to a whole number.
        scoreText.text = currentScore.ToString("0");
    }
}
