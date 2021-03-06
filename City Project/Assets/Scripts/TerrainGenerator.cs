﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int[,] map;
    public GameObject[] tiles;
    public int[] angles;

    public bool waterblockplaced = false;

    void Start()
    {
        int mapheight = 50;
        int mapwidth = 50;

        int random;

        Vector2 shift = new Vector2((int)(Random.Range(0,100)), (int)(Random.Range(0, 100))); // play with this to shift map around
        Vector2 cityShift = new Vector2((int)(Random.Range(0, 100)), (int)(Random.Range(0, 100))); // play with this to shift map around
        float zoom = 0.1f; // play with this to zoom into the noise field

        for (float x = 0; x < mapwidth; x+= 1f)
        {
            for (float y = 1; y < mapheight; y+= 1f)
            {
                Vector2 pos = zoom * (new Vector2(x, y)) + shift;
                float noise = Mathf.PerlinNoise(pos.x, pos.y);

                Vector2 cityPos = zoom * (new Vector2(x, y)) + cityShift;
                float cityNoise = Mathf.PerlinNoise(cityPos.x, cityPos.y);

                if (noise < 0.2f)
                {
                    random = 11; // Water
                }
                else
                {
                    random = 4; // Land
                }

                float newy = 0;
                // Creates Hexagonal Grid
                if(x%2 == 0)
                {
                    newy = 0.5f;
                }
                else
                {
                    newy = 0;
                }
                // Tile Look
                if(random != 11) //If not water
                {
                    if(noise < 0.75f) // If not mountain
                    {
                        if (cityNoise < 0.1f)
                        {
                            random = 0; // City
                        }
                        else if (cityNoise < 0.15f)
                        {
                            random = 1; // Urban
                        }
                        else if (cityNoise < 0.2f)
                        {
                            random = 2; // Suburban
                        }
                        else if (cityNoise < 0.25f)
                        {
                            random = 3; // Rural
                        }
                        else
                        {
                            random = 4; // Land
                        }
                    }
                    else if (noise < 0.8f) // If on slope of mountain
                    {
                        if (cityNoise < 0.1f)
                        {
                            random = 1; // Urban
                        }
                        else if (cityNoise < 0.15f)
                        {
                            random = 2; // Suburban
                        }
                        else if (cityNoise < 0.2f)
                        {
                            random = 3; // Rural
                        }
                        else
                        {
                            random = 4; // Land
                        }
                    }
                    else // If mountain
                    {
                        random = 6; // Mountain
                    }
                    
                    if(noise < 0.8f) // Generate Land tiles
                    {
                        Instantiate(tiles[random], new Vector3(x, noise / 1.5f, y + newy), Quaternion.identity);
                    }
                    // Deals with rise for mountains
                    else if (noise < 0.85f) // Low mountain
                    {
                        Instantiate(tiles[random], new Vector3(x, noise / 1.25f, y + newy), Quaternion.identity);
                    }
                    else if (noise < 0.9f) // Mountain
                    {
                        Instantiate(tiles[random], new Vector3(x, noise, y + newy), Quaternion.identity);
                    }
                    else if (noise < 0.95f) // High mountain
                    {
                        Instantiate(tiles[random], new Vector3(x, noise * 1.5f, y + newy), Quaternion.identity);
                    }
                    else // Highest mountain
                    {
                        Instantiate(tiles[random], new Vector3(x, noise * 2f, y + newy), Quaternion.identity);
                    }
                }
                else // Water
                {
                    Instantiate(tiles[random], new Vector3(x, 0.18f, y + newy), Quaternion.identity);
                }
            }
        }
    }
}
