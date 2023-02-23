using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void HelpButton()
    {
        MenuManager.GoToMenu(MenuName.HelpMenu);
    }

    public void StartGame()
    {
        MenuManager.GoToMenu(MenuName.GameplayMenu);
    }

    public void CreditsScene()
    {
        MenuManager.GoToMenu(MenuName.CreditsMenu);
    }
}
