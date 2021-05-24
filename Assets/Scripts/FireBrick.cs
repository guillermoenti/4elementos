using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBrick : Brick
{
    BoxCollider2D boxCollider;
    [SerializeField] GameObject Burst_particles;
    [SerializeField] BallController Ball;

    int count;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public override void HitBehaviour()
    {
       

        //Instancio particulas del bloque de fuego
        Instantiate(Burst_particles, this.transform.position, Quaternion.Euler(0, 0, 0));

        //mirando si tiene bloques arriba, abajo, derecha e izquierda
        Vector2 topPosition = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y);
        Vector2 bottomPosition = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.max.y);
        Vector2 leftPosition = new Vector2(boxCollider.bounds.min.x, boxCollider.bounds.center.y);
        Vector2 rightPosition = new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.center.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(topPosition, Vector2.up, 40);
        CheckRaycastWithScenario(hits);

        hits = Physics2D.RaycastAll(bottomPosition, -Vector2.up, 40);
        CheckRaycastWithScenario(hits);

        hits = Physics2D.RaycastAll(leftPosition, -Vector2.right, 40);
        CheckRaycastWithScenario(hits);

        hits = Physics2D.RaycastAll(rightPosition, Vector2.right, 40);
        CheckRaycastWithScenario(hits);

        //Destruyo el bloque de fuego
        Destroy(gameObject);

    }

    private void CheckRaycastWithScenario(RaycastHit2D[] hits)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Block") 
                {
                    Instantiate(Burst_particles, hit.collider.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                    Destroy(hit.collider.gameObject);
                    Ball.blocksBroken++;
                }
            }
        }
    }
}
