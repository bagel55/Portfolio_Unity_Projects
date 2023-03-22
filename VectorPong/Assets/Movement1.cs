using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    private float maxy = 4;
    private float minY = -4;
    private float CurrentY;
    private float MovementSpeed = 10;
    void Update()
    {
        float Yvel = Input.GetAxis("Vertical1");
        Vector2 position = transform.position;
        position.y = position.y + 1 * Yvel * MovementSpeed * Time.deltaTime;
        transform.position = position;
        CurrentY = gameObject.transform.position.y;
        if (CurrentY > 4)
        {
            gameObject.transform.position = new Vector2(-4, maxy);
        }
        if (gameObject.transform.position.y < -4)
        {
            gameObject.transform.position = new Vector2(-4, minY);
        }
    }
}
