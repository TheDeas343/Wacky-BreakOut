using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region Fields
    Rigidbody2D rb2d;
    int bonus = 1;
    float halfWidht;

    const float BounceAngleHalfRange = Mathf.Deg2Rad * 60;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, -35, 0);
        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
        halfWidht = box2d.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float verticalPosition = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;
        if (verticalPosition != 0)
        {
            position.x += bonus * verticalPosition * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
        }

        transform.position = position;

        ClampX();
    }

    void ClampX()
    {
        Vector3 position = transform.position;


        // horizontal
        if (position.x - halfWidht < ScreenUtils.ScreenLeft) { position.x = ScreenUtils.ScreenLeft + halfWidht; }
        else if (position.x + halfWidht > ScreenUtils.ScreenRight) { position.x = ScreenUtils.ScreenRight - halfWidht; }

      
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidht;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}
