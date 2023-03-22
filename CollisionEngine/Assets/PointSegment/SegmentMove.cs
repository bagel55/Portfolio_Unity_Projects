using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentMove : MonoBehaviour
{
    public GameObject endpoint1, endpoint2;
    LineRenderer lr;   

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, endpoint1.transform.localPosition);
        lr.SetPosition(1, endpoint2.transform.localPosition);
    }
}
