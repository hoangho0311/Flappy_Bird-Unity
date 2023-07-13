using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;
    public UILoseGame loseGamePanel;
    public GameObject playButton;
    public GameObject textScore;
    public GameObject logo;
    public GameObject pauseButton;
    public GameObject clickToPlayButton;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        clickToPlayButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void UIPlay()
    {
        playButton.SetActive(false);
        loseGamePanel.Close();
        logo.SetActive(false);
        textScore.SetActive(true);
    }

    public void GameOver()
    {
        textScore.SetActive(false);
        pauseButton.SetActive(false);

        StartCoroutine(WaitForLose(2));
    }

    public void IncreaseScore()
    {
        scoreText.text = DataManager.instance.GetScore().ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private IEnumerator WaitForLose(float duration)
    {
        yield return new WaitForSeconds(duration);
        int playerScore = DataManager.instance.GetScore();
        loseGamePanel.Show();
        loseGamePanel.SetPlayerScoreText(playerScore);
        loseGamePanel.SetMedalImage(playerScore);

        int bestScore = PlayerPrefs.GetInt("BestScore");
        loseGamePanel.SetBestScoreText(bestScore);
    }
}
