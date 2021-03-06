﻿using System.Collections;
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
    int[] nonPanneaux = new[] { 0, 1,3,4,5 };
    int panneaux = 0;

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
                if (n == 2 && panneaux == 0)
                {
                    panneaux = 1;
                }
                else
                {
                    n = nonPanneaux[r.Next(nonPanneaux.Length)];
                }
                print(n);
                Instantiate(buildings[n], pos, Quaternion.identity);
               

                
            }
        }
    }

    
}
