using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBrick : Brick
{
    [SerializeField] PaddleController Paddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HitBehaviour()
    {
        Paddle.is_light = true;
        Destroy(gameObject);
    }
}
