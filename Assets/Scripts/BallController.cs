using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    //[SerializeField] GameObject Follow;
    [SerializeField] Transform paddle;

    Vector2 axis;
    Vector2 movement;

    float speed = 300.0f;
    float paddle_margin = 28f;
    float timer;
    public bool is_light;

    public int blocksBroken;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        axis.y = 1;
        axis.x = 0;
        timer = 0;
        is_light = false;
        blocksBroken = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_light)
        {
            speed = 500;
            //Follow.GetComponent<ParticleSystem>().Play();
            timer += Time.deltaTime;
            if (timer > 5)
            {
                is_light = false;
                timer = 0;
            }
        }
        else
        {
            speed = 300;
            //Follow.GetComponent<ParticleSystem>().Stop();
        }
        if(blocksBroken == 66)
        {
            GameManager.Instance.level++;
            GameManager.Instance.changeLevel = true;
            blocksBroken = 0;
        }
        
    }

    private void FixedUpdate()
    {
        movement = new Vector2(axis.x * speed, axis.y * speed);
        rigidBody.velocity = movement;
    }

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
            blocksBroken++;
        }
        else if (collision.gameObject.tag == "Limit")
        {
            axis.x *= -1;
        }
        else if (collision.gameObject.tag == "TopLimit")
        {
            axis.y *= -1;
        }
        else if (collision.gameObject.tag == "Lose")
        {
            gameObject.transform.position = new Vector3(0, -250, 0);
            axis.y *= -1;
            paddle.position = new Vector3(0, -320, 0);
            if (GameManager.Instance.lives == 1)
            {
                GameManager.Instance.changeLevel = true;
            }
            GameManager.Instance.GetHit();

        }
    }
}
