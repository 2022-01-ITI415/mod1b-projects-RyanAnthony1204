using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    [Header("Set in Inspector")]
    public float playerSpeed;
    private Rigidbody rb;
    public int lives;
    public static int points = 0;
    private float movementX;
    public static bool goal = false;
    public static bool dead = false;
    public static bool door = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);

        rb.AddForce(movement * playerSpeed);
    }

    public void Check()
    {
        int x = 0;
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Point");
        foreach(GameObject g in keys)
        {
            x++;
        }
        if(x == 0)
        {
            door = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            Check();
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            lives--;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            if (lives == 2)
            {
                c.a = 0.6f;
                mat.color = c;
            }else if(lives == 1)
            {
                c.a = 0.35f;
                mat.color = c;
            }else if(lives == 0)
            {
                Destroy(this.gameObject);
                dead = true;
            }
        }

        if (other.gameObject.CompareTag("EndPoint") && door)
        {
           goal = true;
        }
    }

}
