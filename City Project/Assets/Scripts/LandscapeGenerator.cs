using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeGenerator : MonoBehaviour
{
    public GameObject[] cityBlock;
    private int currentTile;
    private bool task;

    void Start()
    {
        switch(gameObject.name)
        {
            case "CityTop(Clone)":
                currentTile = 1;
                break;
            case "UrbanTop(Clone)":
                currentTile = 2;
                break;
            case "SuburbsTop(Clone)":
                currentTile = 3;
                break;
            case "RuralTop(Clone)":
                currentTile = 4;
                break;
            case "HillTop(Clone)":
                currentTile = 5;
                break;
        }
    }
    
    void Update()
    {
    }
}
