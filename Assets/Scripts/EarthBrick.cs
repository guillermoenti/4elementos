using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBrick : Brick
{

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void HitBehaviour()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.mass = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Lose")
        {
            Destroy(this);
        }
        if(collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
    }

}
