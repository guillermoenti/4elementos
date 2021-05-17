using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject NormalBlocks = null;
    public GameObject DirtBlocks = null;
    public GameObject FireBlocks = null;
    public GameObject WaterBlocks = null;
    public GameObject AirBlocks = null;

    //int maxblocks;
    //int h_blocks;
    //int v_blocks;

    int X;
    int Y;

    // Start is called before the first frame update
    void Start()
    {
        //maxblocks = 66;
        //h_blocks = 11;
        //v_blocks = 6;

        X = -500;
        Y = 280;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate()
    {
       for (int h = 0; h > 11; h++)
       {
           for (int v = 0; v > 6; v++)
           {
               float rand = Random.Range(0.0f, 1.4f);
               if (rand <= 1.0f)
               {
                   Instantiate(NormalBlocks, new Vector3(X, Y, 0), Quaternion.identity);
               }
               else if (rand == 1.1f)
               {
                   Instantiate(DirtBlocks, new Vector3(X, Y, 0), Quaternion.identity);
               }
               else if (rand == 1.2f)
               {
                   Instantiate(FireBlocks, new Vector3(X, Y, 0), Quaternion.identity);
               }
               else if (rand == 1.3f)
               {
                   Instantiate(WaterBlocks, new Vector3(X, Y, 0), Quaternion.identity);
               }
               else if (rand == 1.4f)
               {
                   Instantiate(AirBlocks, new Vector3(X, Y, 0), Quaternion.identity);
               }
               X += 100;
           }
           Y += 36;
       }
    }
}