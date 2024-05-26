using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScore : MonoBehaviour
{
    public Text scoreDisplay;
    float score;
    float scoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        scoreIncrease = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        score += scoreIncrease * Time.deltaTime;

        if (scoreDisplay != null)
        {
            scoreDisplay.text = score.ToString("mm':'ss'.'ff");
        }
    }
}