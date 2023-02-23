using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LoseMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ActualScore;
    [SerializeField]
    TextMeshProUGUI HighScore;

    const string actualScore = "YOUR SCORE : ";
    static int score;

    const string highScore = "HIGH SCORE : ";
    static int high;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        score = HUD.Score;

        ActualScore.text = actualScore + score.ToString();

        if(PlayerPrefs.HasKey("High Score"))
        { 
            if (PlayerPrefs.GetInt("High Score") < score)
            {
                PlayerPrefs.SetInt("High Score", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("High Score", score);
            PlayerPrefs.Save();
        }

        HighScore.text = highScore + PlayerPrefs.GetInt("High Score").ToString();

    }

    public void QuitButton()
    {
        Time.timeScale = 1;
       
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }

    public void RestartButton()
    {
        
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.GameplayMenu);
    }
}
