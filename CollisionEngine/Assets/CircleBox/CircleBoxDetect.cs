using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoxDetect : MonoBehaviour
{
    public GameObject box1, A, I;
    private void Update()
    {
        float t1, b1, l1, r1;

        t1 = box1.transform.position.y + box1.transform.localScale.y / 2;
        b1 = box1.transform.position.y - box1.transform.localScale.y / 2;
        l1 = box1.transform.position.x - box1.transform.localScale.x / 2;
        r1 = box1.transform.position.x + box1.transform.localScale.x / 2;

        float CAX = A.transform.position.x;
        float CAY = A.transform.position.y;
        float CAR = A.transform.localScale.x / 2;

        bool hasCollision = VGDCollisionEngine.CircleBox(CAX, CAY, CAR, t1, b1, l1, r1);
        I.GetComponent<Indicate>().SetValue(hasCollision);
    }
}
