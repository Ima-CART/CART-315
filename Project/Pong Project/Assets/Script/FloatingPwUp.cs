using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPwUp : MonoBehaviour
{
    public Rigidbody2D rd2d;

    public float maxSpeed = 4f;

    public float startY;

    public float startX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        InitialFloat();
    }

    private void InitialFloat()
    {
        Vector2 dir = Vector2.left;
    }
    private void Reset()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
