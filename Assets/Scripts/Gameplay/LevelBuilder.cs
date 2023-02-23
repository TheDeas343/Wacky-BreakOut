using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabPaddle;
    [SerializeField]
    GameObject prefabBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    List<Sprite> spriteBonusList = new List<Sprite>();
    [SerializeField]
    List<Sprite> spriteList = new List<Sprite>();
    [SerializeField]
    GameObject prefabHUD;


    GameOverEvent goEvent = new GameOverEvent();

    private bool gameOver = false;

    
    void Start()
    {
        EventManager.AddInvokerGameOver(this);
        MenuManager.Pause = false;


        Instantiate(prefabPaddle);
        

        GameObject Util = Instantiate<GameObject>(prefabBlock); 
        BoxCollider2D box2d = Util.GetComponent<BoxCollider2D>();

        float sizeX = box2d.size.x;
        float sizeY = box2d.size.y;
        int widht = (int)((ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft )/ sizeX);
        

        float initialBlocks = (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) * 3 / 5;

        Vector2 spawnPosition = new Vector2(ScreenUtils.ScreenLeft+ sizeX/2,ScreenUtils.ScreenBottom + initialBlocks );
        for (int i = 0; i < 6; i++)
        {
            if(i == 2 || i == 4) 
            {
                for (int j = 0; j < widht; j++)
                {
                   

                  
                        if(i == 2)
                        {
                            prefabBonusBlock.GetComponent<SpriteRenderer>().sprite = spriteBonusList[0];
                            Instantiate(prefabBonusBlock, spawnPosition, Quaternion.identity);
                        }
                        else
                        {
                            prefabBonusBlock.GetComponent<SpriteRenderer>().sprite = spriteBonusList[1];
                            Instantiate(prefabBonusBlock, spawnPosition, Quaternion.identity);
                        }
                    
                   
                    spawnPosition.x += sizeX;

                }
            }
            else
            {
                for (int j = 0; j < widht; j++)
                {
                    prefabBlock.GetComponent<SpriteRenderer>().sprite = spriteList[i];
                    Instantiate(prefabBlock, spawnPosition, Quaternion.identity);
                    spawnPosition.x += sizeX;

                }
            }
            spawnPosition.x = ScreenUtils.ScreenLeft + sizeX / 2;
            spawnPosition.y += sizeY;
        }

        Destroy(Util);

        
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuManager.Pause )
        {
            MenuManager.Pause = true;
            MenuManager.GoToMenu(MenuName.PauseMenu);
        }

        if (!gameOver)
        {
            
            if (GameObject.Find("StandarBlock(Clone)") == null)
            {
                MenuManager.Pause = true;
                gameOver = true;
                goEvent.Invoke(1);
            }

            if (HUD.BallsLeft <= 0)
            {
                MenuManager.Pause = true;
                gameOver = true;
                goEvent.Invoke(0);
            }

            
        }
    }

    public void AddListener(UnityAction<int> listener)
    {
        goEvent.AddListener(listener);
    }

    
}
