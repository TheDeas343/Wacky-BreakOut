using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    float angle = -90;
    Rigidbody2D rb2d;

    Timer waitTime;
    bool doForce = true;

    Vector3 normalVelocity;

    BallDiedEvent Event = new BallDiedEvent();

    Vector2 force;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddInvokerBallSpawner(this);
        
        transform.position = new Vector3(0, -15, 0);
        rb2d = GetComponent<Rigidbody2D>();

        waitTime = gameObject.AddComponent<Timer>();
        waitTime.Duration = 2;
        waitTime.Run();
       
    }

    public void SetDirection(Vector3 direction)
    {
        float curretnVelocity = rb2d.velocity.magnitude;
        rb2d.velocity = curretnVelocity * direction;

        normalVelocity = rb2d.velocity;
        HUD.Velocity(normalVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime.Finished && doForce)
        {
            force = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
            rb2d.AddForce(force * ConfigurationUtils.BallImpulseForce);
            doForce = false;
        }
        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            
            EventManager.RemoveInvokerBallSpawner();
            Event.Invoke();
        }
    }

    public void changeVelocity(float vel)
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity *= Mathf.Sqrt(vel);
        HUD.Velocity(rb2d.velocity);
    }

    public void changeVelocity(bool value)
    {
        if (value)
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = normalVelocity;
            HUD.Velocity(normalVelocity);

        }
    }

    public void AddListener(UnityAction listener)
    {
        Event.AddListener(listener);
    }

}
