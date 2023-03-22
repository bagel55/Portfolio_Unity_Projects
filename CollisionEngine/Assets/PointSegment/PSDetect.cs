using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSDetect : MonoBehaviour
{
    public GameObject P, E1, E2, I;
    public float buffer;

    void Update()
    {
        float pX = P.transform.position.x;
        float pY = P.transform.position.y;
        float e1X = E1.transform.position.x;
        float e1Y = E1.transform.position.y;
        float e2X = E2.transform.position.x;
        float e2Y = E2.transform.position.y;

        bool hasCollided = VGDCollisionEngine.PointSegment(pX, pY, e1X, e1Y, e2X, e2Y, buffer);
        I.GetComponent<Indicate>().SetValue(hasCollided);
    }
}
