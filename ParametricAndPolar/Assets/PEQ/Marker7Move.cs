using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker7Move : MonoBehaviour
{
    TrailRenderer TR;
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
        TR.enabled = false;
        transform.position = PEQ.Strophoid(0);
        TR.enabled = true;
    }
    void Update()
    {
        float t = Time.time;
        transform.position = PEQ.Strophoid(t);
    }
}
