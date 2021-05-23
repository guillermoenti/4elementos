using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    BoxCollider2D boxCollider;

    [SerializeField] GameObject FollowLeft;
    [SerializeField] GameObject FollowRight;

    GameObject part;

    Vector2 axis;
    Vector2 movement;

    KeyCode leftButton = KeyCode.LeftArrow;
    KeyCode rightButton = KeyCode.RightArrow;

    float maxX;
    float minX;
    float y;
    float z;
    float speed = 300.0f;
    float timer;
    public bool is_light;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        is_light = false;
        maxX = boxCollider.bounds.max.x;
        minX = boxCollider.bounds.min.x;
        y = boxCollider.bounds.max.y;
        z = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_light)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                is_light = false;
                timer = 0;
            }
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
