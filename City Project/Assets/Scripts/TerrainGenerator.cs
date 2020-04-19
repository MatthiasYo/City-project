using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int[,] map;

    public GameObject[] tiles;

    public int[] angles;

    void Start()
    {
        int mapheight = 30;
        int mapwidth = 30;

        int random;

        Vector2 shift = new Vector2((int)(Random.Range(0,100)), (int)(Random.Range(0, 100))); // play with this to shift map around
        float zoom = 0.1f; // play with this to zoom into the noise field

        for (float x = 0; x < mapwidth; x+= 1f)
        {
            for (float y = 1; y < mapheight; y+= 1f)
            {
                Vector2 pos = zoom * (new Vector2(x, y)) + shift;
                float noise = Mathf.PerlinNoise(pos.x, pos.y);
                if (noise < 0.2f)
                {
                    random = 0;
                    //map[x, y] = 0; // water
                }
                else if (noise < 0.25f)
                {
                    random = 1;
                    //map[x, y] = 2; // sand
                }
                else if (noise < 0.3f)
                {
                    random = 2;
                    //map[x, y] = 1; // land
                }
                else if (noise < 0.35f)
                {
                    random = 3;
                    //map[x, y] = 3; // mountain
                }
                else if (noise < 0.5f)
                {
                    random = 4;
                }
                else if (noise < 0.6f)
                {
                    random = 5;
                }
                else if (noise < 0.7f)
                {
                    random = 4;
                }
                else
                {
                    random = 6;
                }

                float newy = 0;

                if(x%2 == 0)
                {
                    newy = 0.5f;
                }
                else
                {
                    newy = 0;
                }

                Instantiate(tiles[random], new Vector3(x, 0, y + newy), Quaternion.Euler(new Vector3(0, angles[(int)(Random.Range(0, angles.Length))], 0)));
            }
        }
    }
    
    void Update()
    {
        
    }
}
