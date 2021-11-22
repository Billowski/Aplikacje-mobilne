using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth = 28.0f;
    private float speed = 10;

    private PlayerController playerControllerScript;
    void Start()
    {
        startPos = transform.position;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }

        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
