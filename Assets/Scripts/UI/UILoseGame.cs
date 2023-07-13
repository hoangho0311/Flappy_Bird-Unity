using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILoseGame : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI bestScoreText;
    public Image medalImage;

    public Sprite goldSprite, silverSprite, bronzeSprite;
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void SetPlayerScoreText(int score)
    {
        playerScoreText.text = score.ToString();
    }

    public void SetBestScoreText(int score)
    {
        bestScoreText.text = score.ToString();
    }

    public void SetMedalImage(int score)
    {
        if (score >= 7)
        {
            medalImage.sprite = goldSprite;
        }else if (score >= 4)
        {
            medalImage.sprite = silverSprite;
        }
        else
        {
            medalImage.sprite = bronzeSprite;
        }
    }

    public void PlayAgainOnclicked()
    {
        SceneManager.LoadScene("CutScene");
    }
}
