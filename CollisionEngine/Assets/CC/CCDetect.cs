using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCDetect : MonoBehaviour
{
    public GameObject A, B, I;
    void Update()
    {
        float CAX = A.transform.position.x;
        float CAY = A.transform.position.y;
        float CAR = A.transform.localScale.x / 2;

        float CBX = B.transform.position.x;
        float CBY = B.transform.position.y;
        float CBR = B.transform.localScale.x / 2;

        bool hasCollided = VGDCollisionEngine.CircleCircle(CAX, CAY, CAR, CBX, CBY, CBR);
        I.GetComponent<Indicate>().SetValue(hasCollided);
    }
}
