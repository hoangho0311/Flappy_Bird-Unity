using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameManager : MonoBehaviour
{
    public Image imageBTN;
    public Sprite buttonPauseSprite;
    public Sprite buttonResumeSprite;

    private void Start()
    {
        if (GameManager.instance.isPauseGame)
        {
            imageBTN.sprite = buttonResumeSprite;
        }
        else
        {
            imageBTN.sprite = buttonPauseSprite;
        }
    }

    public void PauseGameOnclicked()
    {
        GameManager.instance.PauseGameMNG();
        if (GameManager.instance.isPauseGame)
        {
            imageBTN.sprite = buttonResumeSprite;
        }
        else
        {
            imageBTN.sprite = buttonPauseSprite;
        }
    }
}
