using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController playerControllerScript;

    private float speed = 10.0f;
    private float zDestroy = -26.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.position = transform.position + Vector3.back * speed * Time.fixedDeltaTime;
        }

        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
