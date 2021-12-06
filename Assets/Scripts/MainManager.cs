using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    public int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public string name;
        public int score;
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    public void SaveHighscore()
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = playerName, score = playerScore };
        string jsonString = PlayerPrefs.GetString("highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        highscores.highscoreEntryList.Add(highscoreEntry);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        if (highscores.highscoreEntryList.Count > 10)
        {
            highscores.highscoreEntryList.RemoveRange(10, highscores.highscoreEntryList.Count - 10);
        }

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore", json);
        PlayerPrefs.Save();
    }
}
