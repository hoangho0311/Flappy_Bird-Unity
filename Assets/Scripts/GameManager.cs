using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BirdControl player;
    public static GameManager instance;
    public bool gameOver;
    public bool isStartGame;
    public bool isPauseGame;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        isStartGame = false;
        gameOver = false;
        isPauseGame = false;
        player.enabled = false;
        Pause();  
    }

    public void Pause()
    {
        player.enabled = false;
    }

    public void Play()
    {
        player.transform.position = Vector3.zero;
        gameOver = false;
        Time.timeScale = 1; 
        UIManager.instance.UIPlay();
        player.enabled = true;
        

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void StartGame()
    {
        isStartGame = true;
        UIManager.instance.StartGame();
    }

    public void GameOver()
    {
        DataManager.instance.SetBestScore();
        isStartGame = false;
        gameOver = true;
        UIManager.instance.GameOver();
        Pause();
    }

    public void IncreaseScore()
    {
        DataManager.instance.AddScore();
        int playerScore = DataManager.instance.GetScore();
        UIManager.instance.UpdateScore(playerScore);
    }

    public void PauseGameMNG()
    {
        if (isPauseGame == false)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPauseGame = true;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        isPauseGame = false;
        Time.timeScale = 1;
    }
}
