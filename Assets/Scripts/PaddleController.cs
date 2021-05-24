using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    [SerializeField] GameObject FollowLeft;
    [SerializeField] GameObject FollowRight;

    Vector2 axis;
    Vector2 movement;

    KeyCode leftButton = KeyCode.LeftArrow;
    KeyCode rightButton = KeyCode.RightArrow;

    float speed;
    float timer;
    public bool is_light;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        is_light = false;
        speed = 300.0f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_light)
        {
            speed = 500;
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
        }

        if (Input.GetKey(leftButton))
        {
            axis.x = -1;
            if (is_light)
            {
                FollowLeft.GetComponent<ParticleSystem>().Play();
            }
        }
        else if (Input.GetKey(rightButton))
        {
            axis.x = 1;
            if (is_light)
            {
                FollowRight.GetComponent<ParticleSystem>().Play();
            }
        }
        else 
        { 
            axis.x = 0;
            FollowRight.GetComponent<ParticleSystem>().Stop();
            FollowLeft.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector2(axis.x * speed, rigidBody.velocity.y);
        rigidBody.velocity = movement;
    }
}
