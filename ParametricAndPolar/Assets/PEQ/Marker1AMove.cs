using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker1AMove : MonoBehaviour
{
    TrailRenderer TR;
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        TR.enabled = false;
        transform.position = PEQ.Circle3D(0, 4);
        TR.enabled = true;
    }
    void Update()
    {
        float t = Time.time;
        transform.position = PEQ.Circle3D(t * 2, 4);
    }
}
