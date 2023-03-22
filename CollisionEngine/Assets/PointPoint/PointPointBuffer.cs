using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPointBuffer : MonoBehaviour
{
    public GameObject A, B, I;
    public float buffer;

    void Update()
    {
        float Ax = A.transform.position.x;
        float Ay = A.transform.position.y;
        float Bx = B.transform.position.x;
        float By = B.transform.position.y;

        bool hasCollided = VGDCollisionEngine.PointPointBuffer(Ax, Ay, Bx, By, buffer);
        I.GetComponent<Indicate>().SetValue(hasCollided);
    }
}
