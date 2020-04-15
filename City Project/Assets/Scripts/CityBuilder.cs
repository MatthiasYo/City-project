using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour
{
    public GameObject[] cityBlock;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                Instantiate(cityBlock[(int)Random.Range(0,5)], new Vector3(j, 0, i), Quaternion.identity);
            }
        }
    }
    
    void Update()
    {
        
    }
}
