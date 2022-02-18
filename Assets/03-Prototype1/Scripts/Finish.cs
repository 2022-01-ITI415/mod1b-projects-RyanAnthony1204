using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    static private Finish S;
    
    void Start()
    {
        S = this;
    }
    
    void Update()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Point");
        if (Player.points >= (keys.Length * 100))
        {
            
        }
    }
}
