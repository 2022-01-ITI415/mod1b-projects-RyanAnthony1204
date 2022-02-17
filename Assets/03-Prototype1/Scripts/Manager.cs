using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        level = Instantiate<GameObject>(levels[stage]);
    }
}
