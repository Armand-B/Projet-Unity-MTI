using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public int mapWith = 20;
    public int mapHeight = 20;
    public float buildingFootPrint;
    int[] angles = new[] { 0, 90, 180, 270 };

    // Start is called before the first frame update
    void Start()
    {
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWith; w++)
            {
                System.Random r = new System.Random();
                Vector3 pos = new Vector3(w * buildingFootPrint, 0, h * buildingFootPrint);
                int n = UnityEngine.Random.Range(0, buildings.Length);       
                Instantiate(buildings[n], pos, /*Quaternion.Euler(0, angles[r.Next(angles.Length)], 0)*/ Quaternion.identity);
               

                
            }
        }
    }

    
}
