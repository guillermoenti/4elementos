using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBrick : Brick
{
    [SerializeField] PaddleController Paddle;
    [SerializeField] BallController Ball;
    [SerializeField] GameObject Burst_particles;

    public override void HitBehaviour()
    {
        //hacemos ligeras a la pala y la bola
        Paddle.is_light = true;
        Ball.is_light = true;

        //Instancio particulas del bloque de aire
        Instantiate(Burst_particles, this.transform.position, Quaternion.Euler(0, 0, 0));

        //Destruyo el bloque de fuego
        Destroy(gameObject);
    }
}
