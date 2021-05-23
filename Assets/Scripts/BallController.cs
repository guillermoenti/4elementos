using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    Vector2 axis;
    Vector2 movement;

    float speed = 300.0f;
    float paddle_margin = 28f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        axis.y = 1;
        axis.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement = new Vector2(axis.x * speed, axis.y * speed);
        rigidBody.velocity = movement;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            float ballX = transform.position.x;
            float objX = collision.collider.bounds.center.x;
            if (ballX < objX - paddle_margin)
            {
                axis.y *= -1;
                axis.x = -0.5f;
            }
            else if (ballX > objX + paddle_margin)
            {
                axis.y *= -1;
                axis.x = 0.5f;
            }
            else
            {
                axis.y *= -1;
                axis.x = 0;
            }
        }
        else if (collision.gameObject.tag == "Block")
        {
            float ballX = transform.position.x;
            float ballY = transform.position.y;
            float objMaxX = collision.collider.bounds.max.x;
            float objMinX = collision.collider.bounds.min.x;
            float objMaxY = collision.collider.bounds.max.y;
            float objMinY = collision.collider.bounds.min.y;
            if (ballX > objMinX && ballX < objMaxX)
            {
                axis.y *= -1;
                
            }
            else if (ballY > objMinY && ballY < objMaxY)
            {
                axis.x *= -1;
                
            }
            
        }
        else if (collision.gameObject.tag == "Limit")
        {
            axis.x *= -1;
        }
        else if (collision.gameObject.tag == "TopLimit")
        {
            axis.y *= -1;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            float ballX = transform.position.x;
            float objX = collision.GetComponent<BoxCollider2D>().bounds.center.x;
            if (ballX < objX - paddle_margin)
            {
                axis.y *= -1;
                axis.x = -0.5f;
            }
            else if (ballX > objX + paddle_margin)
            {
                axis.y *= -1;
                axis.x = 0.5f;
            }
            else
            {
                axis.y *= -1;
                axis.x = 0;
            }
        }
        else if (collision.gameObject.tag == "Block")
        {
            float ballX = transform.position.x;
            float ballY = transform.position.y;
            float objMaxX = collision.GetComponent<BoxCollider2D>().bounds.max.x;
            float objMinX = collision.GetComponent<BoxCollider2D>().bounds.min.x;
            float objMaxY = collision.GetComponent<BoxCollider2D>().bounds.max.y;
            float objMinY = collision.GetComponent<BoxCollider2D>().bounds.min.y;
            if (ballX > objMinX && ballX < objMaxX)
            {
                axis.y *= -1;
            }
            else if (ballY > objMinY && ballY < objMaxY)
            {
                axis.x *= -1;
            }
            collision.gameObject.GetComponent<Brick>().HitBehaviour();
        }
        else if (collision.gameObject.tag == "Limit")
        {
            axis.x *= -1;
        }
        else if (collision.gameObject.tag == "TopLimit")
        {
            axis.y *= -1;
        }
    }
}
