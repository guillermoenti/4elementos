using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    //BoxCollider2D boxCollider;

    Vector2 axis;
    Vector2 movement;

    KeyCode leftButton = KeyCode.LeftArrow;
    KeyCode rightButton = KeyCode.RightArrow;

    float speed = 200.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftButton))
        {
            axis.x = -1;
        }
        else if (Input.GetKey(rightButton))
        {
            axis.x = 1;
        }
        else { axis.x = 0; }
    }

    private void FixedUpdate()
    {
        movement = new Vector2(axis.x * speed, rigidBody.velocity.y);
        rigidBody.velocity = movement;

    }
}
