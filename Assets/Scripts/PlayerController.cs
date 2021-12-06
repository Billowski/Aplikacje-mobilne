using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public ParticleSystem dirtParticle;

    public Text gameOverText;
    public Button homeButton;
    public Button highScoreButton;
    public Button retryButton;
    
    private bool isOnGround = true;

    private GameManager gameManager;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private Touch touch;

    private float speed = 500.0f;
    private float jumpForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (!gameOver)
        {
            float horizontalInput = Input.acceleration.x;
            playerRb.AddForce(Vector3.right * speed * horizontalInput);

            if (Input.touchCount > 0)
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
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
        highScoreButton.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        MainManager.Instance.SaveHighscore();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
