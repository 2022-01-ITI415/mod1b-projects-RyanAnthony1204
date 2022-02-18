using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float bottomY = -10f;
    void Update()
    {
        if(transform.position.y <= bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
