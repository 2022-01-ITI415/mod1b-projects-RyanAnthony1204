using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player: MonoBehaviour
{
    [Header("Set in Inspector")]
    public float playerSpeed;
    public TextMeshProUGUI pointsDisplay;
    public GameObject winDisplay;
    private Rigidbody rb;
    private int points;
    private float movementX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;

        ScoreCounter();
        winDisplay.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
    }

    void ScoreCounter()
    {
        pointsDisplay.text = "Score: " + points.ToString();
        if(points >= 100)
        {
            winDisplay.SetActive(true);
        }
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

            ScoreCounter();
        }
    }

}
