using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPaddle : MonoBehaviour
{
    public float scaler = 2;
    public Prect paddleR;
    private Color lPaddleColor = new Color(1, 1, 0, 1);
    void Start()
    {
        paddleR = new Prect("right Paddle", 1850, 100, 10, 90, true, "PADDLE");
        Manager.colliderPrects.Add(paddleR);
    }
    void Update()
    {
        paddleR.rect.y += -scaler * Input.GetAxis("Vertical");
        if (paddleR.rect.y < 30) paddleR.rect.y = 30;
        if (paddleR.rect.y > Screen.height - 50) paddleR.rect.y = Screen.height - 50;
        if(Manager.ballLocation.x > Screen.width / 2)
        {
            paddleR.rect.y = Manager.ballLocation.y - 45;
        }
    }
    private void OnGUI()
    {
        Manager.GUIDrawRect(paddleR.rect, lPaddleColor);
    }
}
