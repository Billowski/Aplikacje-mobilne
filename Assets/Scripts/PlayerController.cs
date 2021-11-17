using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isOnGround = true;

    private Touch touch;

    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float zBound = 0;

    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.acceleration.x;
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            playerRb.velocity = (Vector3.back * 3) + (Vector3.right * playerRb.velocity.x);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if(collision.gameObject.CompareTag("Enemy 2"))
        {
            Destroy(gameObject);
        }
    }
}
