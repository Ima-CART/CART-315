using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public Paddle lastHit;
    public float maxInitialAngle = 0.62f;
    public float moveSpeed = 1f;
    public float maxStartY = 4f;
    public float speedMultiplier = 1.1f;
    private float startX = 0f;


    private void Start()
    {

        IntialPush();


    }

    private void IntialPush()
    {
        Vector2 dir = Vector2.left;
        if (Random.value < 0.5f)
        {
            dir = Vector2.right;
        }
        // Vector2 dir = Random value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;

    }

    private void ResetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.gameObject.GetComponent<Paddle>();

        if (paddle)
        {
            lastHit = paddle;
            rb2d.linearVelocity *= speedMultiplier;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            ResetBall();
            IntialPush();
        }
    }

}
