using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    static private Manager S;
    
    [Header("Set in Inspector")]
    public GameObject[] levels;

    [Header("Set Dynamically")]
    public int stage;
    public int stageMAX;
    public GameObject level;

    void Start()
    {
        S = this;
        stage = 0;
        stageMAX = levels.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if(level != null)
        {
            Destroy(level);
        }
        
        Player.goal = false;
        Player.dead = false;
        
        level = Instantiate<GameObject>(levels[stage]);
    }

    void NextLevel()
    {
        stage++;
        if(stage >= stageMAX)
        {
            stage = 0;
        }

        StartLevel();
    }

    void Update()
    {
        if(Player.goal == true)
        {
            NextLevel();
        }
        if(Player.dead == true)
        {
            stage = 0;
            StartLevel();
        }
    }
}
