using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreUIHandler : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        LoadHighscore();
    }

    private void LoadHighscore()
    {
        string jsonString = PlayerPrefs.GetString("highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string RankString;
        switch (rank)
        {
            default:
                RankString = rank + "th";
                break;
            case 1:
                RankString = "1st";
                break;
            case 2:
                RankString = "2nd";
                break;
            case 3:
                RankString = "3rd";
                break;
        }
        entryTransform.Find("posText").GetComponent<Text>().text = RankString;

        int score = highscoreEntry.score;
        entryTransform.Find("nameText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("scoreText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public int score;
    }

    public void Cancel()
    {
        SceneManager.LoadScene(0);
    }
}
