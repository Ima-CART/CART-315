using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingPwUp : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float maxSpeed = 1f;

    public float startY;

    public float startX = 0f;
    //Boolean to mark that if the powerup has been hit
    bool hasBeenHit = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(InitialFloat());
        // InitialFloat();
    }

    private IEnumerator InitialFloat()
    {
        while (!hasBeenHit)
        {
            ChangeDirection();
            yield return new WaitForSeconds(0.5f);
        }


    }

    private IEnumerator ResetPowerUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(3f);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    private void Reset()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

        if (ball)
        {
            if (ball.lastHit)
            {

                float newY = Mathf.Min(ball.lastHit.transform.localScale.y * 1.2f, 3f);
                ball.lastHit.transform.localScale = new Vector3(
                    ball.lastHit.transform.localScale.x,
                    newY,
                    ball.lastHit.transform.localScale.z
                );
                StartCoroutine(ResetPowerUp());
            }
            // gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("TopBorder"))
        {
            Vector2 dir = new Vector2(Random.Range(-3, 3), Random.Range(-2, 0));
            rb2d.linearVelocity = dir * maxSpeed;

        }

        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            Vector2 dir = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
            rb2d.linearVelocity = dir * maxSpeed;
        }

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("TopBorder"))
    //     {
    //         Vector2 dir = new Vector2(Random.Range(-3, 3), Random.Range(-2, 0));
    //         rb2d.linearVelocity = dir * maxSpeed;

    //     }

    //     if (collision.gameObject.CompareTag("BottomBorder"))
    //     {
    //         Vector2 dir = new Vector2(Random.Range(-3, 3), Random.Range(1, 2));
    //         rb2d.linearVelocity = dir * maxSpeed;
    //     }

    // }

    private void ChangeDirection()
    {
        float xDirection;

        if (transform.position.x < -8)
        {
            // Too far left, so move right
            xDirection = Random.Range(1, 3);
        }
        else if (transform.position.x > 5)
        {
            // Too far right, so move left
            xDirection = -Random.Range(1, 3);
        }
        else
        {
            // Middle: move randomly
            xDirection = Random.Range(-2, 3);
        }

        float yDirection = Random.Range(-2, 3);

        Vector2 dir = new Vector2(xDirection, yDirection);

        rb2d.linearVelocity = dir.normalized * maxSpeed;
    }


    // Update is called once per frame
    void Update()
    {


    }
}
