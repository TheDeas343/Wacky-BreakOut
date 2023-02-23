using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{
    static bool pause = false;

    public static bool Pause
    {
        get { return pause; }

        set { pause = value; }
    }


    public  static void GoToMenu(MenuName menu)
    {
        switch (menu)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.GameplayMenu:
                SceneManager.LoadScene("GameplayMenu");
                break;
            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.LoseMenu:
                Object.Instantiate(Resources.Load("LoseMenu"));
                break;
            case MenuName.WinMenu:
                Object.Instantiate(Resources.Load("WinMenu"));
                break;
            case MenuName.HelpMenu:
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.CreditsMenu:
                SceneManager.LoadScene("CreditsScene");
                break;

        }
    }
}
