using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animation;
    public float jumpForce;
    public float jumpAngle;
    public float angleRotateSpeed;


    void Start()
    {
        this.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();

        rb.gravityScale = 0;
    }

    void Update()
    {
        bool isTap = Input.GetKeyDown(KeyCode.Space);
        if (isTap && GameManager.instance.isPauseGame == false)
        {
            GameManager.instance.StartGame();
            Jump();
        }
        if (GameManager.instance.isStartGame == false)
        {
            rb.gravityScale = 0;
            return;
        }

        RotateBird();
    }

    void Jump()
    {
        AudioManager.instance.PlayFlapAudio();
        rb.gravityScale = 1;
        animation.SetTrigger("Fly");
        rb.velocity = Vector2.up * jumpForce;
        transform.eulerAngles = new Vector3(0, 0, jumpAngle);
    }


    protected void RotateBird()
    {
        transform.eulerAngles -= new Vector3(0, 0, angleRotateSpeed * Time.deltaTime);
        if(transform.eulerAngles.z <= -30f)
        {
            transform.eulerAngles -= new Vector3(0, 0, -30f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scoring")
        {
            AudioManager.instance.PlayPointAudio();
            GameManager.instance.IncreaseScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (GameManager.instance.gameOver == true) return;
            AudioManager.instance.PlayHitAudio();
            transform.eulerAngles = new Vector3(0, 0, -jumpAngle);
            GameManager.instance.GameOver();
        }
    }
}
