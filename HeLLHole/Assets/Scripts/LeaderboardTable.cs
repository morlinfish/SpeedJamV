using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardTable : MonoBehaviour
{
      
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        /*
       highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry() {score = 50000},
            new HighscoreEntry() {score = 100000},
            new HighscoreEntry() {score = 150000},
            new HighscoreEntry() {score = 960000},
            new HighscoreEntry() {score = 660000},
        };*/

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score < highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;

                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
      
      //  Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
      //  string json = JsonUtility.ToJson(highscores);
      //  PlayerPrefs.SetString("highscoreTable", json);
        //PlayerPrefs.SetString("highscoreTable", "100");
      //  PlayerPrefs.Save();
      //  Debug.Log(PlayerPrefs.GetString("highscoreTable"));
      
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 90f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        float score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }
    /*
    private void AddHighscoreEntry (int score)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    */
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;

    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        
    }
}
