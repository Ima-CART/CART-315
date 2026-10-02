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
    private void Reset()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
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

    private void ChangeDirection()
    {
        Vector2 dir = new Vector2(Random.Range(-2, 2), Random.Range(-3, 3));
        rb2d.linearVelocity = dir * maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
