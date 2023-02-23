using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    #region Fields

    int redPoitns=50;
    int orangePoints = 100;
    int yellowPoints=150;
    int greenPoints=200;
    int bluePoints=250;
    int purplePoints=300;

    protected PointAddedEvent EventBlock = new PointAddedEvent();
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddInvokerAddPoint(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Sprite actualSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        int points= 0;
        if (actualSprite.name == "Vermelho") { points = redPoitns; }
        else if(actualSprite.name == "Laranja") { points = orangePoints; }
        else if( actualSprite.name == "Amarelo") { points = yellowPoints; }
        else if (actualSprite.name == "Verde") { points = greenPoints; }
        else if (actualSprite.name == "Azul") { points = bluePoints; }
        else if (actualSprite.name == "Roxo") { points = purplePoints; }
        EventBlock.Invoke(points);
        Destroy(gameObject);
    }

    public void AddListener(UnityAction<int> listener)
    {
        EventBlock.AddListener(listener);
    }
}
