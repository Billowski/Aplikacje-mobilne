using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private int timer;

    public Text playerName;
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerName.text = MainManager.Instance.playerName;
        MainManager.Instance.playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            timer++;
            if (timer > 100)
            {
                MainManager.Instance.playerScore += 10;
                timer = 0;
            }
            textScore.text = "Score: " + MainManager.Instance.playerScore.ToString();
        }
    }
}
