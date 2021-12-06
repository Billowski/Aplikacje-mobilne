using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Highscore()
    {
        SceneManager.LoadScene(2);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
