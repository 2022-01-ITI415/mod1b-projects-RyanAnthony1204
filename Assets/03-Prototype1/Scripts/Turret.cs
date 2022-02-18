using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject bulletPrefab;
    public float speed = 1f;
    public float secBetweenBullets = 1f;

    void Start()
    {
        Invoke("Fire", 2f);
    }

    
    void Fire()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = transform.position;
        Invoke("Fire", secBetweenBullets);
    }
}
