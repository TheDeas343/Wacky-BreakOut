using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    TextMeshProUGUI ballsLeftText;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI velocityText;
    [SerializeField]
    TextMeshProUGUI timeText;

    // balls left text support
    const string BallsLeftPrefix = "Balls Left: ";
    static int ballsLeft = 5;
    
    // score text support
    const string ScorePrefix = "Score: ";
    static int score = 0;

    // velocity
    const string VelocityPrefix = "Velocity: ";
    static float velocity = 0;

    // time
    const string TimePrefix = "Time: ";
    public Timer passedTime; 


    


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();

        score = 0;
        scoreText.text = ScorePrefix + score.ToString();

        velocity = 0;
        velocityText.text = VelocityPrefix + velocity.ToString();

        passedTime = gameObject.AddComponent<Timer>();
        passedTime.Counter();
  
        timeText.text = TimePrefix + (passedTime.ElaspsedSeconds).ToString();

        EventManager.AddListenerBallSpawner(LoseBall);
        EventManager.AddListenerAddPoint(AddPoint);



    }

    public static int BallsLeft
    {
        get { return ballsLeft; }
    }

    public static int Score
    {
        get { return score; }
    }

    // Update is called once per frame
    void Update()
    {   
       
        velocityText.text = VelocityPrefix + ((int)velocity).ToString();
        ChangeTime(passedTime,timeText);
        
    }

    private void  LoseBall()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
    }

    private void AddPoint(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();


    }



    public static void Velocity(Vector3 vel)
    {
        velocity = vel.magnitude;
    }

    public static void ChangeTime( Timer passedTime, TextMeshProUGUI timeText)
    {
        float time = passedTime.ElaspsedSeconds;
        int hours = (int) time / 3600;

        time = time - 3600 * hours;

        int minutes = (int) time / 60;

        time = time - minutes * 60;

        int seconds = (int) time;

        if(hours == 0)
        {
            if(minutes < 10)
            {
                if(seconds < 10)
                {
                    timeText.text = TimePrefix +"0" +minutes.ToString() + ":" + "0"+seconds.ToString();
                }
                else
                {
                    timeText.text = TimePrefix + "0" + minutes.ToString() + ":" + seconds.ToString();
                }
            }
            else
            {
                if (seconds < 10)
                {
                    timeText.text = TimePrefix  + minutes.ToString() + ":" + "0" + seconds.ToString();
                }
                else
                {
                    timeText.text = TimePrefix  + minutes.ToString() + ":" + seconds.ToString();
                }
            }
        }

        else
        {
            timeText.text = TimePrefix + "0" + hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
