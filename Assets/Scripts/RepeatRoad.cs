using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth = 28.0f;
    private float speed = 20;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }

        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
