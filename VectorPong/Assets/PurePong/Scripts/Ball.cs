﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 ballVelocity;
    public Vector2 ballLocation;
    public float speed;
    public Prect ball;
    private Color ballColor = new Color(0,1,0,1);
    void Start()
    {
        ball = new Prect("Ball", Screen.width / 2, Screen.height / 2, 10, 10, true, "Ball");
        ballVelocity = new Vector2(3, 3);
        ballLocation = new Vector2(ball.rect.x, ball.rect.y);
        speed = Manager.initBallSpeed;
    }
    void Update()
    {
        ball.rect.x += speed * ballVelocity.normalized.x;
        ball.rect.y += speed * ballVelocity.normalized.y;
        CheckCollisions(ball);
        CheckOutOfBounds(ball);
        Manager.ballLocation = new Vector2(ball.rect.x, ball.rect.y);
    }
    public void CheckCollisions(Prect b)
    {
        foreach(Prect target in Manager.colliderPrects)
        {
            if (b.rect.Overlaps(target.rect)) //still using unity here... cringe
            {
                Debug.Log("Collision with " + target.name);
                if (target.tag == "WALL")
                {
                    ballVelocity.y = -ballVelocity.y;
                }
                if(target.tag == "PADDLE")
                {
                    ballVelocity.x = -ballVelocity.x;
                }
                //increse speed after collision
                speed *= 1.05f;
            }
        }
    }
    private void CheckOutOfBounds(Prect b)
    {
        if(b.rect.x < 0)
        {
            Manager.rightScore++;
            BallReset();
        }
        if (b.rect.x > Screen.width)
        {
            Manager.leftScore++;
            BallReset();
        }
    }
    private void BallReset()
    {
        ballVelocity = new Vector2(Random.Range(1, 3), Random.Range(1, 3));
        ball.rect.x = Screen.width / 2;
        ball.rect.y = Screen.height / 2;
        speed = Manager.initBallSpeed;
    }
    private void OnGUI()
    {
        Manager.GUIDrawRect(ball.rect, ballColor);
    }
}
