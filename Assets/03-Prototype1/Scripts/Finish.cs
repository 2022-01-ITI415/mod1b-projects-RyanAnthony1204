using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public static int count = 0;

    void Start()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Point");
        foreach(GameObject g in keys)
        {
            count++;
        }
    }
    void Update()
    {    
        if (Player.door)
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
