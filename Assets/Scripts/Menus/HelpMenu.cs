using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    // Start is called before the first frame update
  

  
    public void BacktoMainMenu()
    {
        
        MenuManager.GoToMenu(MenuName.MainMenu);
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.MainMenu);
        }
    }
}
