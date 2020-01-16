using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 1.0f;
    public Vector2 velocity = Vector2.zero;
    public int ballStartSide = 0;
    void Start()
    { 
        try {
            rb = GetComponent<Rigidbody2D>();    
        } catch(NullReferenceException ex) {
            Debug.Log("Nie znaleziono rigidbody");
        }
        transform.position = new Vector3(0, 0, transform.position.z);

        var randomNumberGenerator = new System.Random();
        ballStartSide = randomNumberGenerator.Next(0,2);

        switch(ballStartSide) {
            case 0: {
                velocity = Vector2.up; // (x,y) -> (-1,0)
                break;
            }
            case 1: {
                velocity = Vector2.down; // (x,y) -> (1,0)
                break;
            }
            default: {
                velocity = Vector2.up;
                break;
            }
        }
        //
    }

    
    void Update()
    {
        rb.velocity = velocity * (Time.deltaTime * movementSpeed);
    }

    void Bounce(Vector2 normal){
        velocity = velocity * 1.1f;
        velocity = new Vector2(velocity.x * normal.x, velocity.y * normal.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Wall")
        {
            Wall wall = other.transform.GetComponent<Wall>();
            if(wall) {
                Bounce(wall.normal);
            }
        }
    }
}
