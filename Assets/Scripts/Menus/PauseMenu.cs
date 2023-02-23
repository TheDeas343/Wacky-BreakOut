using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            MenuManager.Pause = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        MenuManager.Pause = false;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }

    public void ResumeButton()
    {
        MenuManager.Pause = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
