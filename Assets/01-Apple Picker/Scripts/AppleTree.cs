using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab for instaiating apples
    public GameObject applePrefab;

    //Speed at which the Tree moves
    public float speed = 1f;

    //Distance where the Tree turns around
    public float leftAndRightEdge = 10f;

    //Chance the Tree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apple will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Directions
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); //Move right
        }else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed); //Move left
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections){
            speed *= -1; //Change direction randomly
        }
    }
}
