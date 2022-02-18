using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    void Update()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Point");
        if (Player.points >= (keys.Length * 100))
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
