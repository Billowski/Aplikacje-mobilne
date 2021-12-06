using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string playerName;

    public Text error;

    public void StartGame()
    {
        playerName = transform.GetChild(2).GetComponent<InputField>().text;
        SavePlayerName();
        if(playerName != "")
        {
            SceneManager.LoadScene(1);
        } else
        {
            error.gameObject.SetActive(true);
        }
        
    }

    public void Highscore()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SavePlayerName()
    {
        if (MainManager.Instance.playerName == "" || playerName != "")
            MainManager.Instance.playerName = playerName;
    }

}
