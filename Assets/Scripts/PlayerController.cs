using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isOnGround = true;

    private float speed = 2;
    private float jumpForce = 5;
    private float zBound = 6.0f;
    private float xBound = 9.125f;

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
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup 1"))
        {
            Destroy(other.gameObject);
            p1();
        }
        if (other.gameObject.CompareTag("Powerup 2"))
        {
            Destroy(other.gameObject);
            p2();
        }
    }

    IEnumerator PowerupConutdown()
    {
        yield return new WaitForSeconds(7);
        speed = 2;
        jumpForce = 5;
    }

    private void p1()
    {
        speed = 3;
        StartCoroutine(PowerupConutdown());
    }
    private void p2()
    {
        jumpForce = 7;
        StartCoroutine(PowerupConutdown());
    } 
}
