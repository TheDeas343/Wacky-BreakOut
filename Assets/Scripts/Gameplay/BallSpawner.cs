using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabBall;

    GameObject currentBall;

    int numBalls = 4;


    void Start()
    {
        currentBall = Instantiate<GameObject>(prefabBall);

        EventManager.AddListenerBallSpawner(SpawnBall);
    }

    // Update is called once per frame
    
    

    private void SpawnBall()
    {
       
        Destroy(currentBall);
        if (numBalls > 0)
        {
            currentBall = Instantiate<GameObject>(prefabBall);
            numBalls--;
        }
        
    }
}
