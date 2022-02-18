using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player: MonoBehaviour
{
    [Header("Set in Inspector")]
    public float playerSpeed;
    private Rigidbody rb;
    public static int points;
    private float movementX;
    public static int lives = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;

        ScoreCounter();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
    }

    void ScoreCounter()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);

        rb.AddForce(movement * playerSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            points = points + 100;

            Manager.updateScore(points);

            ScoreCounter();
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            lives--;
            Manager.updateLives(lives);
            if (lives == 0)
            {
                Destroy(this.gameObject);
                Manager.updateWin("Game Over!");
            }
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }

}
