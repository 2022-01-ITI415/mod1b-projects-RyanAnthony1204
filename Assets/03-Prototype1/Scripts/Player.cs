using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    [Header("Set in Inspector")]
    public float playerSpeed;
    private Rigidbody rb;
    public static int points;
    private float movementX;
    public int lives = 3;
    public static bool goal = false;
    public static bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Point");
        if(other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            points = points + 100;
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            lives--;
            if (lives == 2)
            {
                c.a = 0.7f;
                mat.color = c;
            }else if(lives == 1)
            {
                c.a = 0.4f;
                mat.color = c;
            }else if(lives == 0)
            {
                Destroy(this.gameObject);
                dead = true;
            }
        }

        if (other.gameObject.CompareTag("EndPoint") && (points >= (keys.Length * 100)))
        {
           goal = true;
        }
    }

}
