using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int currentScore = 0;

    private void Awake()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            currentScore = 0;
            PlayerPrefs.SetInt("FirstPlay", 0);
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void AddScore()
    {
        currentScore++;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        
    }

    public void SetBestScore()
    {
        int lastBestScore = PlayerPrefs.GetInt("BestScore");
        if (currentScore > lastBestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
    }
}
