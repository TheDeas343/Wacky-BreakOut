using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListenerGameOver(GameOver);
    }

    public void GameOver(int type)
    {
        MenuManager.Pause = true;
        if (type == 0)
        {
            MenuManager.GoToMenu(MenuName.LoseMenu);
        }

        if (type == 1)
        {
            MenuManager.GoToMenu(MenuName.WinMenu);
        }
    }
}
