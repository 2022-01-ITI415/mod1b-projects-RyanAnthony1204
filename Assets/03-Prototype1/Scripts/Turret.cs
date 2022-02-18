using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject bulletPrefab;
    public float speed = 2f;
    public float secBetweenBullets = 1f;

    void Start()
    {
        Invoke("Fire", 0.5f);
    }

    
    void Fire()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = transform.position;
        Invoke("Fire", secBetweenBullets);
    }
}
