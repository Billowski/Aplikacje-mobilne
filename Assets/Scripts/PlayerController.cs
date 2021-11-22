using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public ParticleSystem dirtParticle;

    private bool isOnGround = true;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private Touch touch;

    private float speed = 100.0f;
    private float jumpForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
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
                dirtParticle.Stop();
                playerAnim.SetTrigger("Jump_trig");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
