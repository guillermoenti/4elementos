using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : Brick
{
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
        Destroy(this);
    }
}
