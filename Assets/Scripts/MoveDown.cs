using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 0.3f;
    private float zDestroy = -10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.back * speed * Time.fixedDeltaTime;

        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
