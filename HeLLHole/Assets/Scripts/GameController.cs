using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public GameObject hudContainer, gameOverPanel;
    public Text timeCounter, platformCounter;
    public bool gamePlaying { get; private set; }

    private float startTime, elapsedTime;
    TimeSpan timePlaying;
   
    private void Awake()
    {
         instance = this;
    }
    private void Start()
    {
        platformCounter.text = "";


        gamePlaying = true;
    }
    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;

    }

    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }


    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
        string timePlayingStr = "Final Time: " + timePlaying.ToString("mm':'ss'.'ff");
        gameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
    }


}

