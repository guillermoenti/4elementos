using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBrick : Brick
{
    private Rigidbody2D rb2d;
    private BoxCollider2D box2D;

    [SerializeField] float mass = 0.0f;
    [SerializeField] float gravity = 0.0f;

    const int layerEarthMoving = 8;

    [SerializeField] GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }

    public override void HitBehaviour()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.mass = mass;
        rb2d.gravityScale = gravity;
        gameObject.layer = layerEarthMoving;
        InstanciateParticles();

        Debug.Log("Tierra");
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Block")
        {
            InstanciateParticles();
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag == "Paddle")
        {
            GameManager.Instance.GetHit();
            InstanciateParticles();
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Lose")
        {
            Destroy(gameObject);
        }
    }

    private void InstanciateParticles()
    {
        Instantiate(particle, new Vector3(this.box2D.bounds.center.x, this.box2D.bounds.min.y, 0), Quaternion.Euler(0, 0, 0)); 
    }
}
