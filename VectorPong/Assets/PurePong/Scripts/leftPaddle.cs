using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPaddle : MonoBehaviour
{
    public float scaler = 2;
    public Prect paddleL;
    private Color lPaddleColor = new Color(1, 1, 0, 1);
    void Start()
    {
        paddleL = new Prect("Left Paddle", 50, 100, 10, 90, true, "PADDLE");
        Manager.colliderPrects.Add(paddleL);
    }
    void Update()
    {
        paddleL.rect.y += -scaler * Input.GetAxis("Vertical1");
        if (paddleL.rect.y < 30) paddleL.rect.y = 30;
        if (paddleL.rect.y > Screen.height - 120) paddleL.rect.y = Screen.height - 120;
    }
    private void OnGUI()
    {
        Manager.GUIDrawRect(paddleL.rect, lPaddleColor);
    }
}
