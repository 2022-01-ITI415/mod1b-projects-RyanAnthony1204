using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    static private Manager S;
    
    [Header("Set in Inspector")]
    public GameObject[] levels;
    public static Text pointsDisplay;
    public static Text winDisplay;
    public static Text lifeDisplay;

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
        //pointsDisplay.text = "Score: " + Player.points;
        Manager.updateScore(Player.points);
        //winDisplay.text = "Collect the Green Keys!";
        //lifeDisplay.text = Player.lives + " Lives Left";
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

    public static void updateScore(int pts)
    {
        pointsDisplay.text = "Score: " + pts;
    }

    public static void updateLives(int lf)
    {
        lifeDisplay.text = lf + " Lives Left";
    }

    public static void updateWin(string txt)
    {
        winDisplay.text = txt;
    }
}
