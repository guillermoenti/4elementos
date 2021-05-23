using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    BoxCollider2D boxCollider;

    [SerializeField] GameObject FollowParticles;
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
    public bool is_light;
    bool printparticles;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        is_light = true;
        printparticles = true;
        maxX = boxCollider.bounds.max.x;
        minX = boxCollider.bounds.min.x;
        y = boxCollider.bounds.max.y;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftButton))
        {
            axis.x = -1;
            if (is_light && printparticles)
            {
                part = Instantiate(FollowParticles, new Vector3(maxX, y, z), Quaternion.Euler(0, 0, 0));
                printparticles = false;
            }
        }
        else if (Input.GetKey(rightButton))
        {
            axis.x = 1;
            if (is_light && printparticles)
            {
                part = Instantiate(FollowParticles, new Vector3(minX, y, z), Quaternion.Euler(0, 0, 0));
                printparticles = false;
            }
        }
        else 
        { 
            axis.x = 0;
            Destroy(part, 3);
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector2(axis.x * speed, rigidBody.velocity.y);
        rigidBody.velocity = movement;
    }
}
