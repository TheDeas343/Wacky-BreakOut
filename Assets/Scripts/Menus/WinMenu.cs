using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WinMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI BallsLeft;
    [SerializeField]
    TextMeshProUGUI TotalScore;
    [SerializeField]
    TextMeshProUGUI HighScore;

    static int score;
    const int MaxSCORE = 14850;

    const string highScore = "HIGH SCORE : ";
    static int high;

    const string ballsLeft = "BALLS LEFT : ";
    static int left;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        left = HUD.BallsLeft;

        BallsLeft.text = ballsLeft + left.ToString();

        score = MaxSCORE + 30 * left;

        TotalScore.text = score.ToString();


        if (PlayerPrefs.HasKey("High Score"))
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
}
